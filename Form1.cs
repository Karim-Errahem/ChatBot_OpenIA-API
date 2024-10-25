using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenAI_API;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
namespace ChatBot1
{
    public partial class chat : Form
    {
        private readonly OpenAIAPI api;
        public static string text;
        public chat()
        {
            InitializeComponent();
            api = new OpenAIAPI("Your API");
        }

        private void txtMessage_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            { send(); }
        }
        private async Task ChatGPTAsync()
        {

            var chat = api.Chat.CreateConversation();
            chat.AppendUserInput(text);
            string responce = await chat.GetResponseFromChatbotAsync();
            
            AddIncomingMessage(responce);
        }
        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            send();
        }
        async void send()
        {


            


            if (txtMessage.Text.Trim().Length == 0) return;
             text = txtMessage.Text;

            AddOutgoingMessage(txtMessage.Text);
            txtMessage.Text = String.Empty;
            await Task.Run(async () => await ChatGPTAsync());

          

            
        }
       
        private List<Control> messageBubbles = new List<Control>();
        private void AddIncomingMessage(string message)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<string>(AddIncomingMessage), message);
                return;
            }

            var bubble = new ChatItems.Incoming();
            bubble.Message = message;
            AddMessageBubble(bubble);
        }


        private void AddOutgoingMessage(string message)
        {
            var bubble = new ChatItems.OutGoing();
            bubble.Message = message;
            AddMessageBubble(bubble);
           
        }
        private void AddMessageBubble(Control bubble)
        {   
            panel1.Controls.Add(bubble);
            bubble.Width = panel1.Width - 20;
           

            int topPosition = 10; 
            if (messageBubbles.Count > 0)
            {
               
                topPosition = messageBubbles.Last().Bottom + 5;
            }

            bubble.Top = topPosition; 
            messageBubbles.Add(bubble); 
        }

     
    }
}

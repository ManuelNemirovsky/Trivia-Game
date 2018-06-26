using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Diagnostics;

namespace trivya
{
    public partial class Game : Form
    {
        int counter;
        Client client;
        int time;
        int rightAnswers = 0;
        int qNumber;
        Stopwatch sw = new Stopwatch();

        System.Windows.Forms.Timer countDownTimer = new System.Windows.Forms.Timer();
        private void timer1_Tick(object sender, EventArgs e)
        {
            counter--;
            timeLeft.Text = counter.ToString();
            if (counter == 0)
                countDownTimer.Stop();
        }


        static bool exitFlag = false;

        //this timer is for creating a short delay in order to show the user whether his answer was right 
        System.Windows.Forms.Timer myTimer = new System.Windows.Forms.Timer();
        private void myTimerEventProcessor(Object myObject,EventArgs myEventArgs)
        {
            myTimer.Stop();
            exitFlag = true;
        }

        System.Windows.Forms.Timer timeForQuestion = new System.Windows.Forms.Timer();
        private void timeEventProcessor(Object myObject, EventArgs myEventArgs)
        {
            timeForQuestion.Stop();
            sw.Stop();

            client.sendAnswer('5', 10);
            string[] response = client.sendAnswerResponse();
            ans1.BackColor = Color.Red;
            ans2.BackColor = Color.Red;
            ans3.BackColor = Color.Red;
            ans4.BackColor = Color.Red;
            make_gui_pause();
            get_question_or_gameOver();
            
            
        }



        public Game( Client cl, string[] q)
        {
            client = cl;
            InitializeComponent();
            username.Text = client.myName;
            roomName.Text = client.myRoom;

            this.StartPosition = FormStartPosition.CenterScreen;
            string[] question;
            time = client.timePerQuestion;
            qNumber = 1;

            counter = time;
            
            countDownTimer.Tick += new EventHandler(timer1_Tick);
            countDownTimer.Interval = 1000;
            countDownTimer.Start();
            timeLeft.Text = counter.ToString();


            if (q == null)
            {
                client.startGame();
                question = client.getQuestion();
            }
            else
            {
                question = q;
            }

            UpdateQuestionAndAnswer(question);
            myTimer.Tick += new EventHandler(myTimerEventProcessor);
            myTimer.Interval = 500;

            timeForQuestion.Tick += new EventHandler(timeEventProcessor);
            timeForQuestion.Interval = client.timePerQuestion*1000;

            timeForQuestion.Start();
            sw.Start();
        }

        private void UpdateQuestionAndAnswer(string[] question)
        {
            labQues.Text = question[0];
            ans1.Text = question[1];
            ans2.Text = question[2];
            ans3.Text = question[3];
            ans4.Text = question[4];

            ans1.BackColor = SystemColors.Control;
            ans2.BackColor = SystemColors.Control;
            ans3.BackColor = SystemColors.Control;
            ans4.BackColor = SystemColors.Control;


            questionNumber.Text = "Question: " + qNumber.ToString() + "/" + client.numberOfQuestions;
            score.Text = "Score: " + rightAnswers.ToString() + "/" + (qNumber - 1).ToString();
            qNumber++;
        }


        private void exit_Click(object sender, EventArgs e)
        {
            timeForQuestion.Stop();
            countDownTimer.Stop();
            sw.Stop();
            client.LeaveGame();
            this.Owner.Show();
            this.Close();
        }

        void get_question_or_gameOver()
        {
            string[] ans = client.getQuestion();
            if (qNumber <= client.numberOfQuestions)
            {
                UpdateQuestionAndAnswer(ans);
                counter = client.timePerQuestion;
                timeLeft.Text = counter.ToString();
                countDownTimer.Start();
                sw.Restart();
                timeForQuestion.Start();
            }
            else //game over
            {

                string summary = "";
                for (int i = 0; i < ans.Length; i += 2)
                {
                    summary += "username: " + ans[i] + "    score: " + Int32.Parse(ans[i + 1]).ToString() + "\n";
                }

                CustomMessageBox.Show(summary, "Scores");
                
                this.Owner.Show();
                this.Close();
            }

        }

        void make_gui_pause()
        {
            exitFlag = false;

            ans1.Enabled = false;
            ans2.Enabled = false;
            ans3.Enabled = false;
            ans4.Enabled = false;
            myTimer.Start();
            
            while (exitFlag == false)
            {
                Application.DoEvents();
            }
            ans1.Enabled = true;
            ans2.Enabled = true;
            ans3.Enabled = true;
            ans4.Enabled = true;
        }

        private void ans_Click(object sender, EventArgs e)
        {
            timeForQuestion.Stop();
            countDownTimer.Stop();
            sw.Stop();

            Button button = (Button)sender;

            time = (int)sw.ElapsedMilliseconds/1000;

            client.sendAnswer(button.Name[3], time);
            string[] response = client.sendAnswerResponse();
            if (response[0].Equals("1"))
            {
                rightAnswers++;
                button.BackColor = Color.GreenYellow;
            } 
            else
            {
                button.BackColor = Color.Red;
            }
            make_gui_pause();


            get_question_or_gameOver();

        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Math_Quiz
{
    public partial class Form1 : Form
    {
        //generate random numbers

        Random randomizer = new Random();

        //stores addition questions
        int addend1;
        int addend2;
        //stores subraction questions
        int minuend;
        int subtrahend;
        //stores subraction questions
        int multiplicand;
        int multiplier;
        //stores subraction questions
        int dividend;
        int divisor;

        //countdown timer
        int timeLeft;

        //fills in all problems and starts timer
        public void StartTheQuiz()
        {
            //assigns random numbers for math problem
            addend1 = randomizer.Next(51);
            addend2 = randomizer.Next(51);

            //converts numbers into strings and then assignments to the addition labels
            plusLeftLabel.Text = addend1.ToString();
            plusRightLabel.Text = addend2.ToString();

            //makes sure sum field is empty
            sum.Value = 0;

            //fills in subraction problems --- see addition section for comments
            minuend = randomizer.Next(1, 101);
            subtrahend = randomizer.Next(1, minuend);
            minusLeftLabel.Text = minuend.ToString();
            minusRightLabel.Text = subtrahend.ToString();
            difference.Value = 0;

            //fills in multiplication problems --- see addition section for comments
            multiplicand = randomizer.Next(2, 11);
            multiplier = randomizer.Next(2, 11);
            timesLeftLabel.Text = multiplicand.ToString();
            timesRightLabel.Text = multiplier.ToString();
            product.Value = 0;

            //fills in division problems --- see addition section for comments
            divisor = randomizer.Next(2, 11);
            int temporaryQuotient = randomizer.Next(2, 11);
            dividend = divisor * temporaryQuotient;
            dividedLeftLabel.Text = dividend.ToString();
            dividedRightLabel.Text = divisor.ToString();
            quotient.Value = 0;


            //starts timer
            timeLeft = 30;
            timeLabel.Text = "30 seconds";
            timer1.Start();
            timeLabel.BackColor = Color.White;
        }

        //checks answers
        private bool CheckTheAnswer()
        {
            if ((addend1 + addend2 == sum.Value)
            && (minuend - subtrahend == difference.Value)
            && (multiplicand * multiplier == product.Value)
            && (dividend / divisor == quotient.Value))
                return true;
            else
                return false;
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void startButton_Click(object sender, EventArgs e)
        {
            StartTheQuiz();
            startButton.Enabled = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (CheckTheAnswer())
            {
                //stops game if answer is correct
                timer1.Stop();
                MessageBox.Show("You got all the answers right!",
                                "Congratulations!");
                startButton.Enabled = true;
            }
            else if (timeLeft > 0)
            {
                //counts down if answer is not correct
                timeLeft--;
                timeLabel.Text = timeLeft + " seconds";
            }
            else
            {
                //stops game if time is up
                timer1.Stop();
                timeLabel.Text = "Time's up!";
                MessageBox.Show("You didn't finish in time.", "Sorry!");
                sum.Value = addend1 + addend2;
                difference.Value = minuend - subtrahend;
                product.Value = multiplicand * multiplier;
                quotient.Value = dividend / divisor;
                startButton.Enabled = true;
            }

            if (timeLeft <= 5)
            {
                timeLabel.BackColor = Color.Red;
            }
        }

        private void answer_Enter(object sender, EventArgs e)
        {
            //selects answer in answer box
            NumericUpDown answerBox = sender as NumericUpDown;

            if (answerBox != null)
            {
                int lengthOfAnswer = answerBox.Value.ToString().Length;
                answerBox.Select(0, lengthOfAnswer);
            }
        }

        private void sum_ValueChanged(object sender, EventArgs e)
        {
            if (addend1 + addend2 == sum.Value)
            {
                SoundPlayer simpleSound = new SoundPlayer(@"C:\Users\Cliff\source\repos\Math Quiz\chime.wav");
                simpleSound.Play();
            }
        }

        private void difference_ValueChanged(object sender, EventArgs e)
        {
            if (minuend - subtrahend == difference.Value)
            {
                SoundPlayer simpleSound = new SoundPlayer(@"C:\Users\Cliff\source\repos\Math Quiz\chime.wav");
                simpleSound.Play();
            }
        }

        private void multiply_ValueChanged(object sender, EventArgs e)
        {
            if (multiplicand * multiplier == product.Value)
            {
                SoundPlayer simpleSound = new SoundPlayer(@"C:\Users\Cliff\source\repos\Math Quiz\chime.wav");
                simpleSound.Play();
            }
        }

        private void divide_ValueChanged(object sender, EventArgs e)
        {
            if (dividend / divisor == quotient.Value)
            {
                SoundPlayer simpleSound = new SoundPlayer(@"C:\Users\Cliff\source\repos\Math Quiz\chime.wav");
                simpleSound.Play();
            }
        }
    }
}

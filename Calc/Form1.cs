using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calc
{
    public partial class Form1 : Form
    {

        private List<string> values;

        public Form1()
        {
            InitializeComponent();
            this.values = new List<string>();
            this.txtScreen.Text = "0";
        }

        private void EvaluateExp(){
            double result;
            Calc calc = Calc.GetInstance();
            result = calc.EvaluateExpresion(this.values);
            this.values.Clear();
            this.txtScreen.Text = result.ToString();
        }

        private void WriteScreen(char c){
            if (c == '.' && !this.txtScreen.Text.Contains(c)) {
                this.txtScreen.Text += c;
            }else  if(this.txtScreen.Text == "0" && Char.IsDigit(c)){
                this.txtScreen.Text = c.ToString();
            } else if(Char.IsDigit(c)) {
               this.txtScreen.Text += c;
            }
        }

        private void StoreValue(){
            this.values.Add(this.txtScreen.Text);
            if (this.values.Count % 3 == 0) {
                EvaluateExp();
            } else {
                this.txtScreen.Text = "0";
            }
        }

        private void StoreValue(char oper){
            this.values.Add(oper.ToString());
            StoreValue();
        }

        private void BtnDel_Click(object sender, EventArgs e)
        {
            if(this.txtScreen.Text.Length > 1)
            {
                this.txtScreen.Text = this.txtScreen.Text.Substring(0, this.txtScreen.Text.Length - 1);
            } else {
                this.txtScreen.Text = "0";
            }
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            this.txtScreen.Text = "0";
        }

        private void Btn1_Click(object sender, EventArgs e)
        {
            WriteScreen('1');
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            WriteScreen('2');
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            WriteScreen('3');
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            WriteScreen('4');
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            WriteScreen('5');
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            WriteScreen('6');
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            WriteScreen('7');
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            WriteScreen('8');
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            WriteScreen('9');
        }

        private void BtnMult_Click(object sender, EventArgs e)
        {
            StoreValue('*');
        }

        private void btn0_Click(object sender, EventArgs e)
        {
            WriteScreen('0');
        }

        private void btnPoint_Click(object sender, EventArgs e)
        {
            WriteScreen('.');
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            StoreValue('+');
        }

        private void btnSub_Click(object sender, EventArgs e)
        {
            StoreValue('-');
        }

        private void btnDiv_Click(object sender, EventArgs e)
        {
            StoreValue('/');
        }

        private void btnPow_Click(object sender, EventArgs e)
        {
            StoreValue('^');
        }

        private void btnEqual_Click(object sender, EventArgs e)
        {
            StoreValue();
        }
    }
}

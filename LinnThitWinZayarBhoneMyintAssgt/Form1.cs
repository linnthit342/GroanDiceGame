using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;

namespace LinnThitWinZayarBhoneMyintAssgt
{
    public partial class Form1 : Form
    {
        //setting global variables
        ArrayList arlist = new ArrayList();
        ArrayList total_arlist = new ArrayList();
        int runscore;
        ArrayList p1total_arlist = new ArrayList();
        ArrayList p2total_arlist = new ArrayList();
        int p1t_score;
        int p2t_score;
        int dice1;
        int dice2;
        int total_sc;
        string winner;
        int limit;
        string title = "Note";
        string p1_name;
        string p2_name;



        public Form1()
        {
            InitializeComponent();
            p1tscore_tbx.Text = "0";
            p2tscore_tbx.Text = "0";


        }

        private void p1_lbl_Click(object sender, EventArgs e)
        {

        }

        private void p2_lbl_Click(object sender, EventArgs e)
        {

        }



        public void Roll_btn_Click(object sender, EventArgs e)
        {
            try
            {
                p1_name = p1_name_tbx.Text; //take name from players
                p2_name = p2_name_tbx.Text;


                if (p1_name != "" && p2_name != "")
                {
                    if (p1_name.Length <= 7 && p2_name.Length <= 7) //names can't be empty or greater than 7
                    {

                        p1_name_tbx.ReadOnly = true;    // if names cofirmed, can't change back
                        p2_name_tbx.ReadOnly = true;

                        p1_lbl.Text = p1_name;
                        p2_lbl.Text = p2_name;

                        set_random_player();    // call random player function to choose who go first
                        try
                        {
                            limit = int.Parse(limit_tbx.Text);

                            if (limit >= 50 && limit <= 100)    // set limit between 50 and 100 only
                            {

                                limit_tbx.ReadOnly = true;  // to make sure to only take limit score once
                                var dc1 = Resource1.dice1;
                                var dc2 = Resource1.dice2;
                                var dc3 = Resource1.dice3;
                                var dc4 = Resource1.dice4;
                                var dc5 = Resource1.dice5;
                                var dc6 = Resource1.dice6;

                                randice();  // get two random dice numbers
                                Task.Delay(500).Wait(); // delay mini second to display dice numbers

                                // picture box will display respective image for dice1
                                if (dice1 == 1)
                                {
                                    d1.Image = dc1;
                                }
                                else if (dice1 == 2)
                                {
                                    d1.Image = dc2;
                                }
                                else if (dice1 == 3)
                                {
                                    d1.Image = dc3;
                                }
                                else if (dice1 == 4)
                                {
                                    d1.Image = dc4;
                                }
                                else if (dice1 == 5)
                                {
                                    d1.Image = dc5;
                                }
                                else if (dice1 == 6)
                                {
                                    d1.Image = dc6;
                                }


                                // picture box will display respective image for dice2
                                if (dice2 == 1)
                                {
                                    d2.Image = dc1;
                                }
                                else if (dice2 == 2)
                                {
                                    d2.Image = dc2;
                                }
                                else if (dice2 == 3)
                                {
                                    d2.Image = dc3;
                                }
                                else if (dice2 == 4)
                                {
                                    d2.Image = dc4;
                                }
                                else if (dice2 == 5)
                                {
                                    d2.Image = dc5;
                                }
                                else if (dice2 == 6)
                                {
                                    d2.Image = dc6;
                                }


                                check_fun(dice1, dice2);    //call this function to check whether dice != 1

                                if (dice1 == 1 && dice2 == 1)   // if both dices are 1, update total score to 0
                                {
                                    total_sc = 0;
                                    if (cur_pl.Text == p2_name)
                                    {
                                        p1total_arlist.Clear();
                                        p1t_score = 0;
                                        p1tscore_tbx.Text = Convert.ToString(p1t_score);

                                    }
                                    else
                                    {
                                        p2total_arlist.Clear();
                                        p2t_score = 0;
                                        p2tscore_tbx.Text = Convert.ToString(p2t_score);
                                    }

                                }


                                runscore = cal(arlist);    // use calculation(cal) function to calculate current running score

                                runscore_tbx.Text = Convert.ToString(runscore);     // display running score in textbox 


                                announce_winner(p1t_score, p2t_score, runscore);


                                if (winner != "")
                                {
                                    game_reset();
                                }

                            }
                            else
                            {
                                MessageBox.Show("Number should be between 50 and 100 !!", title);
                            }


                        }
                        catch
                        {
                            MessageBox.Show("Please set the limit between 50 and 100 (number only)!!", title);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Player names can't be longer than 7!", "Notice!", MessageBoxButtons.OK);
                    }
                }
                else
                {
                    MessageBox.Show("Please input player names!", "Notice!", MessageBoxButtons.OK);
                }
            }
            catch
            {
                MessageBox.Show("Please type player names!!", title);
            }
            

        }



        private void pass_btn_Click(object sender, EventArgs e)
        {
            try
            {
                p1_name = p1_name_tbx.Text;
                p2_name = p2_name_tbx.Text;
                if (p1_name != "" && p2_name != "")
                {
                    if (p1_name.Length <= 7 && p2_name.Length <= 7)
                    {
                        
                        p1_name_tbx.ReadOnly = true;
                        p2_name_tbx.ReadOnly = true;

                        p1_lbl.Text = p1_name;
                        p2_lbl.Text = p2_name;

                        set_random_player();

                        try
                        {
                            limit = int.Parse(limit_tbx.Text);

                            if (limit >= 50 && limit <= 100)
                            {

                                limit_tbx.ReadOnly = true;  // to make sure to only take limit score once
                                arlist.Clear(); //  reset running score arraylist 



                                total_arlist.Add(runscore); // add running score to total arraylist for calculation
                                total_sc = cal(total_arlist);   //  return total score from total arraylist


                                cal_total(total_sc);    // calculate and get 1P, 2P total score

                                //display in respective textboxes
                                p1tscore_tbx.Text = Convert.ToString(p1t_score);
                                p2tscore_tbx.Text = Convert.ToString(p2t_score);

                                //  after that reset total score and switch player name
                                total_arlist.Clear();
                                Pchange();
                                runscore = 0;
                                announce_winner(p1t_score, p2t_score, runscore);
                            }
                            else
                            {
                                MessageBox.Show("Number should be between 50 and 100 !!", title);
                            }


                        }
                        catch
                        {
                            MessageBox.Show("Please set the limit between 50 and 100 (number only)!!", title);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Player names can't be longer than 7!", "Notice!", MessageBoxButtons.OK);
                    }
                }
                else
                {
                    MessageBox.Show("Please input player names!", "Notice!", MessageBoxButtons.OK);
                }
            }
            catch
            {
                MessageBox.Show("Please input player names!", "Notice!", MessageBoxButtons.OK);
            }

        }



        public int randice()    // funtion to return two random dice numbers
        {
            var random = new Random();
            dice1 = random.Next(1, 7);
            dice2 = random.Next(1, 7);
            return dice1;
            return dice2;
        }



        public string announce_winner(int p1tsc, int p2tsc, int runsc)  //check who is winner and display in textbox
        {
            if (p1tsc + runsc >= limit)
            {
                if (cur_pl.Text == p1_name)
                {
                    winner_tbx.Text = "Congradulation "+p1_name+"!!  You win the Match!";
                }
            }
            else if (p2tsc + runsc >= limit)
            {
                if (cur_pl.Text == p2_name)
                {
                    winner_tbx.Text = "Congradulation " + p2_name + "!!  You win the Match!";
                }              
            }
            else
            {
                winner_tbx.Text = "";
            }
            winner = winner_tbx.Text;
            return winner;

            
        }

        public void set_random_player() //select random player to go first
        {
            if (cur_pl.Text == "")
            {
                string[] p_names = { p1_name, p2_name };
                Random random_player = new Random();
                int index = random_player.Next(p_names.Length);
                cur_pl.Text = p_names[index];
                if (cur_pl.Text == p1_name)
                {
                    cur_pl.ForeColor = Color.Red; //set color according to player, 1P = red, 2P = blue
                }
                else
                {
                    cur_pl.ForeColor = Color.Blue;
                }
            }
        }

        public void game_reset()     //program reset
        {
            MessageBoxButtons button = MessageBoxButtons.OK;
            string msgtxt = "The winner is announced. The game will reset.";
            DialogResult respond = MessageBox.Show(msgtxt, "Congratulation!!", button);
            if (respond == DialogResult.OK)
            {
                this.Hide();
                Form1 f1 = new Form1();
                f1.Show();
            }

        }
    

        // function to check dice numbers
        public void check_fun(int d1, int d2)
        {

            if (d1 != 1 && d2 != 1) // add to arraylist for running score calculation
            {
                arlist.Add(d1);
                arlist.Add(d2);

            }

            else
            {
                arlist.Clear(); //otherwise pass to other player and empty the list

                 Pchange();

            }
        }

        private void d1_no_TextChanged(object sender, EventArgs e)
        {

        }


        // function to sum all the numbers in arraylist and return score
        public int cal(ArrayList arl)
        {
            int sc = 0;
            foreach (int num in arl)
            {
                sc += num;
            }
            return sc;
        }

        // function to calculate and return total score for both players
        public int cal_total(int tsc)   //  input total score and place in right player score list
        {
            if (cur_pl.Text == p1_name)    //current player is 1P => store in 1P arraylist and calculate total score
            {
                p1total_arlist.Add(tsc);
                p1t_score = cal(p1total_arlist);
                return p1t_score;
            }

            else
            {
                p2total_arlist.Add(tsc);
                p2t_score = cal(p2total_arlist);
                return p2t_score;   // otherwise return 2P total score
            }
        }



        //function to change player name after passing dice or encounter 1
        public void Pchange()   
        {
            if (cur_pl.Text == p1_name)
            {
                //Task.Delay(1000).Wait();
                cur_pl.Text = p2_name;
                cur_pl.ForeColor = Color.Blue;  //change current player color
                runscore_tbx.Text = "0";
            }
            else
            {
                //Task.Delay(1000).Wait();
                cur_pl.Text = p1_name;
                cur_pl.ForeColor = Color.Red;   //change current player color
                runscore_tbx.Text = "0";
            }
        }

        private void b2Menu_btn_Click(object sender, EventArgs e)
        {
            // ask user before back to menu
            if (MessageBox.Show("Going back to Menu will not save the match! Exit anyway?", "Back to Menu?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Hide();
                Form2 f2 = new Form2();
                f2.Show();
            }

        }
    }
}

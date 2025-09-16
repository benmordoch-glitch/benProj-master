using System;

namespace benProj.Views;

public partial class SimpleStepper : ContentPage
{
    int num1 = 0;
    int num2 = 0;
    int result = 0;
    string operation = "";
    public SimpleStepper()
    {
        InitializeComponent();
        lblresult.Text = "";

    }



    private void ButtonNumber_Clicked(object sender, EventArgs e)
    {
        Button but = sender as Button;
        lblresult.Text += but.Text;
        if (operation == "")
        {
            num1 += int.Parse(lblresult.Text);
        }
        //  lblresult.Text = "";
        if (operation != "")
        {
            char n = lblresult.Text[2];
            num2 = (int)n;
        }



    }

    private void ButtonOperationClicked(object sender, EventArgs e)
    {
        Button but = sender as Button;
        lblresult.Text += but.Text;
        operation = but.Text;
        result = num1 + num2;
        // lblresult.Text = "";



    }
    private void ButtonEqualClicked(object sender, EventArgs e)
    {
        if (operation == "+")
        {
            lblresult.Text = (num1 + num2).ToString();
        }

    }
    private void ButtonClearClicked(object sender, EventArgs e)
    {


        lblresult.Text = "";
    }


}


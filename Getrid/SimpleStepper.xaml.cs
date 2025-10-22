using System;

namespace benProj.Views;

public partial class SimpleStepper : ContentPage
{
    int num1 = 0;
    int num2 = 0;
    bool before = false;
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
        
        lblresult.Text = but.Text;
        if ( before)
            num1 = int.Parse(lblresult.Text);
        else
            num2 = int.Parse(lblresult.Text);





    }

    private void ButtonOperationClicked(object sender, EventArgs e)
    {
        Button but = sender as Button;

        

        if ("=".Equals(but.Text))
        {
            result = num1;
            before = true;
        }
        else
        {
            operation = but.Text;
            before = true;
            lblresult.Text = "";
        }


        }
    private void ButtonEqualClicked(object sender, EventArgs e)
    {
        if (operation == "+")
        {
            lblresult.Text = $"{num1} + {num2} = {num1 + num2}";
            num1 = num1 + num2;
        }
        if (operation == "-")
        {
            lblresult.Text = $"{num1} - {num2} = {num1 - num2}";
            num1 = num1 - num2;
        }
        //num2 = 0;
        before = true;


    }
    private void ButtonClearClicked(object sender, EventArgs e)
    {
        lblresult.Text = "";
        before = true;
        //num1 = 0;
        //num2 = 0;
    }
}


﻿using System.Windows;

namespace educational_practice.scripts
{
    public static class Buttons
    {

        public static void Exit(Window window)
        {
            window.Close();
        }

        public static void Back(Window current, Window main)
        {
            main.Show();
            current.Close();
        }

        public static void SignOut(Window current, Window main)
        {
            Consts.ID_CURRENT_USER = -1;

            main.Show();
            current.Close();
        }



    }
}

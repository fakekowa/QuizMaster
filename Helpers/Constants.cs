using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace QuizMaster.Helpers
{
    public static class Constants
    {
        public const string baseURI = "https://quizadmincool.azurewebsites.net/Api";
        public const string questionsAPI = "/QuestionsAPI";
    }
}
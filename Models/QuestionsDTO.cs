﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Newtonsoft.Json;
using QuizMaster.Repos;

namespace QuizMaster.Models
{

    public class QuestionsDTO : RepositoryItem
    {
        [JsonProperty(PropertyName = "statement")]
        public string Statement { get; set; }
        [JsonProperty(PropertyName = "categoryId")]
        public int CategoryId { get; set; }
        [JsonProperty(PropertyName = "category")]
        public string Category { get; set; }
    }
}
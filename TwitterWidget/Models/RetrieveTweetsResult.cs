﻿using System;
using System.Collections.Generic;

namespace TwitterWidget.Models
{
    public class RetrieveTweetsResult
    {
        public List<TweetStruct> Tweets { get; set; } = new List<TweetStruct>();
        public bool IsSuccessful { get; set; } = false;
        public Exception Exception { get; set; } = new Exception();
        public DateTime DateTimeExecuted { get; set; } = new DateTime();
        public TwitterOptions Settings { get; set; } = new TwitterOptions();
    }
}
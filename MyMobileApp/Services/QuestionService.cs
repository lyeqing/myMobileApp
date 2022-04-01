using MyMobileApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMobileApp.Services
{
    class QuestionService : IQuestionService<Question>
    {
        readonly List<Question> Questions;

        public QuestionService()
        {
            Questions = new List<Question>()
            {
                new Question { Id = Guid.NewGuid().ToString(),QuestionBody = "Answer this FiveStar",  Type = QuestionType.FiveStar, Selections = new List<string> { }, Description="This is an item description." },
                new Question { Id = Guid.NewGuid().ToString(),QuestionBody = "Answer this LongAnswer", Type = QuestionType.LongAnswer,Selections = new List<string> { }, Description="This is an item description." },
                new Question { Id = Guid.NewGuid().ToString(), QuestionBody = "Answer this MultiChoice",Type = QuestionType.MultiChoice,Selections = new List<string> {"first","second","third"  }, Description="This is an item description." },
                new Question { Id = Guid.NewGuid().ToString(),QuestionBody = "Answer this SeverChoice", Type = QuestionType.SeverChoice,Selections = new List<string> { }, Description="This is an item description." },
                new Question { Id = Guid.NewGuid().ToString(),QuestionBody = "Answer this ShortAnswer", Type = QuestionType.ShortAnswer, Selections = new List<string> { },Description="This is an item description." },
                new Question { Id = Guid.NewGuid().ToString(),QuestionBody = "Answer this SingleChoice", Type = QuestionType.SingleChoice,Selections = new List<string> { "first","second","third" }, Description="This is an item description." },
                new Question { Id = Guid.NewGuid().ToString(),QuestionBody = "Answer this ThreeChoice", Type = QuestionType.ThreeChoice,Selections = new List<string> { }, Description="This is an item description." },
                new Question { Id = Guid.NewGuid().ToString(), QuestionBody = "Answer this YesNo",Type = QuestionType.YesNo,Selections = new List<string> { }, Description="This is an item description." },
                new Question { Id = Guid.NewGuid().ToString(), QuestionBody = "Answer this SingleChoice",Type = QuestionType.SingleChoice,Selections = new List<string> { }, Description="This is an item description." },
                new Question { Id = Guid.NewGuid().ToString(),QuestionBody = "Answer this SingleChoice", Type = QuestionType.SingleChoice,Selections = new List<string> { }, Description="This is an item description." }
            };
        }

        public async Task<bool> AddItemAsync(Question item)
        {
            Questions.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Question item)
        {
            var oldItem = Questions.Where((Question arg) => arg.Id == item.Id).FirstOrDefault();
            Questions.Remove(oldItem);
            Questions.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var oldItem = Questions.Where((Question arg) => arg.Id == id).FirstOrDefault();
            Questions.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<Question> GetItemAsync(string id)
        {
            return await Task.FromResult(Questions.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Question>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(Questions);
        }
    
    }
}

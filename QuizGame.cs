namespace Quiz
{

        public class QuizGame
    {
        
            public int Score { get; private set; }
            public int CorrectAnswers { get; private set; }
            public int TotalQuestionsAnswered { get; private set; }

            // Відсоток правильних відповідей (0 якщо ще не було запитань)
            public double CorrectAnswerPercentage =>
                TotalQuestionsAnswered == 0
                    ? 0.0
                    : (double)CorrectAnswers / TotalQuestionsAnswered * 100.0;

            public void GiveAnswer(bool isCorrect, int points)
            {
                TotalQuestionsAnswered++;

                if (isCorrect)
                {
                    CorrectAnswers++;
                    Score += points;
                }
            }

            public void Restart()
            {
                Score = 0;
                CorrectAnswers = 0;
                TotalQuestionsAnswered = 0;
            }
        }    
}

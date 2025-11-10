using Xunit;
using Quiz; // Підключаємо основний проєкт

namespace Quiz.Tests
{
    public class QuizGameTests
    {
        [Fact]
        public void Constructor_WhenGameStarts_ShouldInitializeWithZeroStats()
        {
            var game = new QuizGame();

            Assert.Equal(0, game.Score);
            Assert.Equal(0, game.CorrectAnswers);
            Assert.Equal(0, game.TotalQuestionsAnswered);
            Assert.Equal(0.0, game.CorrectAnswerPercentage);
        }

        [Fact]
        public void GiveAnswer_WhenCorrect_ShouldIncreaseScoreAndCounts()
        {
            var game = new QuizGame();
            int points = 10;

            game.GiveAnswer(true, points);

            Assert.Equal(10, game.Score);
            Assert.Equal(1, game.CorrectAnswers);
            Assert.Equal(1, game.TotalQuestionsAnswered);
        }
        [Fact]
        public void GiveAnswer_WhenIncorrect_ShouldOnlyIncreaseTotalCount()
        {
            var game = new QuizGame();
            int points = 10;

            game.GiveAnswer(false, points);

            Assert.Equal(0, game.Score);
            Assert.Equal(0, game.CorrectAnswers);
            Assert.Equal(1, game.TotalQuestionsAnswered);
        }

        [Fact]
        public void CorrectAnswerPercentage_When1Of1_ShouldBe100()
        {
            var game = new QuizGame();

            game.GiveAnswer(true, 10);

            Assert.Equal(100.0, game.CorrectAnswerPercentage, 2);
        }
        [Fact]
        public void CorrectAnswerPercentage_When1Of2_ShouldBe50()
        {
            var game = new QuizGame();

            game.GiveAnswer(true, 10);
            game.GiveAnswer(false, 10);

            Assert.Equal(50.0, game.CorrectAnswerPercentage, 2);
        }
        [Fact]
        public void CorrectAnswerPercentage_When3Of4_ShouldBe75()
        {
            var game = new QuizGame();

            game.GiveAnswer(true, 10);
            game.GiveAnswer(true, 10);
            game.GiveAnswer(true, 10);
            game.GiveAnswer(false, 10);

            Assert.Equal(75.0, game.CorrectAnswerPercentage, 2);
        }
        [Fact]
        public void CorrectAnswerPercentage_WhenNoAnswers_ShouldBeZero()
        {
            var game = new QuizGame();
            Assert.Equal(0.0, game.CorrectAnswerPercentage);
        }
        [Fact]
        public void Restart_WhenCalled_ShouldResetAllStats()
        {
            var game = new QuizGame();
            game.GiveAnswer(true, 10);
            game.GiveAnswer(false, 15);
            game.GiveAnswer(true, 5);

            game.Restart();

            Assert.Equal(0, game.Score);
            Assert.Equal(0, game.CorrectAnswers);
            Assert.Equal(0, game.TotalQuestionsAnswered);
            Assert.Equal(0.0, game.CorrectAnswerPercentage);
        }
    }    
}

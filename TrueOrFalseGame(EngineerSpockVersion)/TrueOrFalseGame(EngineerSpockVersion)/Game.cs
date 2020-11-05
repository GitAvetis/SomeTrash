﻿using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace TrueOrFalseGame_EngineerSpockVersion_
{
    public class Game 
    {
        private readonly List<Question> questions;
        private readonly int allowedMistakes;
        private int counter;
        private int mistakes;

        public event EventHandler<GameResultEventArgs> EndOfGame;
        public Game(string filePath, int allowedMistakes=2)
        {
            if (filePath == null)
                throw new ArgumentNullException("filePath");
            if (filePath == "")
                throw new ArithmeticException("filePath should no be empty");
            if (allowedMistakes < 2)
                throw new ArithmeticException("allowedMistakes should be >=2");

            List<Question> questions = File.ReadAllLines(filePath)
                                           .Skip(2)
                                           .Select(x =>
                                           {
                                               string[] parts = x.Split(';');
                                               string text = parts[0];
                                               bool correctAnswer = parts[1].Trim() == "Yes";
                                               string explanation = parts[2];
                                               return new Question(text, correctAnswer, explanation);
                                           }).ToList();

            this.questions = questions;
            this.allowedMistakes = allowedMistakes;
            GameStatus = GameStatus.GameInProgress;

        }

        public GameStatus GameStatus { get; private set; }

        public Question GetNextQuestion()
        {
            return questions[counter];
        }

        public void GiveAnswer(bool answer)
        {
            if (questions[counter].CorrectAnswer != answer)
                mistakes++;
            if (counter == questions.Count - 1 || mistakes > allowedMistakes)
            {
                GameStatus = GameStatus.GameIsOver;
                if (EndOfGame != null)
                    EndOfGame(this, new GameResultEventArgs(counter, mistakes, mistakes <= allowedMistakes));
            }

            counter++;
        }
    }
}

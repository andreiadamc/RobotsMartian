using MartianRobots.Core.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace MartianRobots.Core.Parser.Models
{
    /// <summary>
    /// The base command.
    /// </summary>
    public abstract class BaseCommand
    {
        /// <summary>
        /// Validates input string in a deserialization process
        /// </summary>
        /// <param name="inputText">The input text</param>
        /// <exception cref="ValidationRobotCommandException">Error here</exception>
        public virtual void ValidateInputText(string inputText)
        {
            if (string.IsNullOrEmpty(inputText))
            {
                throw new ValidationRobotCommandException("Input line is empty");
            }

            if (inputText.Length > Constants.MaxLineSize)
            {
                throw new ValidationRobotCommandException(
                    $"Exceeds maximum command line length of {Constants.MaxLineSize} characters.");
            }
        }

        /// <summary>
        /// Validates object properties and fields with validation attributes
        /// </summary>
        public virtual void Validate()
        {
            var validationResults = new List<ValidationResult>();
            var validationContext = new ValidationContext(this);
            if (!Validator.TryValidateObject(this, validationContext, validationResults, true))
            {
                throw new Exception(string.Join(Environment.NewLine, validationResults.Select(s => s.ErrorMessage)));
            }
        }
    }
}

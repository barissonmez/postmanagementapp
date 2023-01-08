using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FluentValidation;
using UI.Models;

namespace UI.Validators
{
    public class PostModelValidator : AbstractValidator<PostRequestModel>
    {
        public PostModelValidator()
        {
            RuleFor(x=> x.Title).NotEmpty().WithMessage("Please specify a title for your post.");
            RuleFor(x=> x.Body).NotEmpty().WithMessage("Please specify a body for your post.");
        }
    }
}
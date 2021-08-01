using CleanArchMvc.Domain.Entities;
using FluentAssertions;
using System;
using Xunit;

namespace CleanArchMvc.Domain.Tests
{
    public class CategoryUnitTest1
    {
        [Fact(DisplayName ="Create Category With Valid State")]
        public void CreateCategory_WithValidParameters_ResultObjectValidState()
        {
            //princípio AAA
            Action action = () => new Category(1, "Category Name");
            action.Should()
                .NotThrow<CleanArchMvc.Domain.Validation.DomainExceptionValidation>();
        }


        [Fact(DisplayName = "Create Category With Invalid id")]
        public void CreateCategory_WithInvalidId_DomainExceptionInvalidId()
        {
            //princípio AAA
            Action action = () => new Category(-1, "Category Name");
            action.Should()
                .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid id"); //validando a mensagem tambem aqui
        }

        [Fact(DisplayName = "Create Category With Name Empty")]
        public void CreateCategory_WithNameEmpty_DomainExceptionRequiredName()
        {
            //princípio AAA
            Action action = () => new Category(1, "");
            action.Should()
                .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid name.Name is required");
        }

        [Fact(DisplayName = "Create Category With Name Null")]
        public void CreateCategory_WithNameEmpty_DomainExceptionNameIsNotNull()
        {
            //princípio AAA
            Action action = () => new Category(1, null);
            action.Should()
                .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid name.Name is required");
        }

        [Fact(DisplayName = "Create Category That Has a Name Less Than 3 Characters")]
        public void CreateCategory_WithNameLessThan3Chars_DomainExceptionNameTooShort()
        {
            //princípio AAA
            Action action = () => new Category(1, "Ca");
            action.Should()
                .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Name too short. Name has to have 3 characters at least");
        }
    }
}

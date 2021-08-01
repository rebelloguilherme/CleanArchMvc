using CleanArchMvc.Domain.Entities;
using FluentAssertions;
using System;
using Xunit;


namespace CleanArchMvc.Domain.Tests
{
    public class ProductUnitTest1
    {
        [Fact(DisplayName ="Create Product With Valid State")]
        public void CreateProduct_WithValidParameters_ResultObjectValidState()
        {
            //princípio AAA
            Action action = () => new Product(1, "Product Name", "Product Description", 10.9m, 1, "Product Image");
            action.Should()
                .NotThrow<CleanArchMvc.Domain.Validation.DomainExceptionValidation>();
        }


        [Fact(DisplayName = "Create Product With Negative Id")]
        public void CreateProduct_WithNegativeId_DomainExceptionNegativeId()
        {
            //princípio AAA
            Action action = () => new Product(-1, "Product Name", "Product Description", 10.9m, 1, "Product Image");
            action.Should()
                .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid Id, it has to be bigger than 0");
                
        }
                       
        [Fact(DisplayName = "Create Product With Name Empty")]
        public void CreateProduct_WithNameEmpty_DomainExceptionNameEmpty()
        {
            //princípio AAA
            Action action = () => new Product(2, "", "Product Description", 10.9m, 1, "Product Image");
            action.Should()
                .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid name. Name is required");

        }

        [Fact(DisplayName = "Create Product With Name Null")]
        public void CreateProduct_WithNameNull_DomainExceptionNameIsNull()
        {
            //princípio AAA
            Action action = () => new Product(2, null, "Product Description", 10.9m, 1, "Product Image");
            action.Should()
                .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid name. Name is required");

        }

        [Fact(DisplayName = "Create Product With Name That Has Less Than 3 Characters")]
        public void CreateProduct_WithNameTooSmall_DomainExceptionNameTooShort()
        {
            //princípio AAA
            Action action = () => new Product(2, "Ba", "Product Description", 10.9m, 1, "Product Image");
            action.Should()
                .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Name too short. Name has to have 3 characters at least");

        }

        [Fact(DisplayName = "Create Product With Description Empty")]
        public void CreateProduct_WithDescriptionEmpty_DomainExceptionDescriptionEmpty()
        {
            //princípio AAA
            Action action = () => new Product(2, "Product Name", "", 10.9m, 1, "Product Image");
            action.Should()
                .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid description. Description is required");

        }

        [Fact(DisplayName = "Create Product With Description Null")]
        public void CreateProduct_WithDescriptionNull_DomainExceptionDescriptionIsNull()
        {
            //princípio AAA
            Action action = () => new Product(2, "Product Name", null, 10.9m, 1, "Product Image");
            action.Should()
                .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid description. Description is required");

        }

        [Fact(DisplayName = "Create Product With Description That Has Less Than 3 Characters")]
        public void CreateProduct_WithDescriptionTooSmall_DomainExceptionDescriptionTooSmall()
        {
            //princípio AAA
            Action action = () => new Product(2, "Product Name", "ba", 10.9m, 1, "Product Image");
            action.Should()
                .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Description too short. Description has to have 3 characters at least");

        }

        [Fact(DisplayName = "Create Product With Price Lower Than 0")]
        public void CreateProduct_WithPriceLessThanZero_DomainExceptionPriceBelowZero()
        {
            //princípio AAA
            Action action = () => new Product(2, "Product Name", "Product Description", -10.9m, 1, "Product Image");
            action.Should()
                .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Price invalid. It has to be higher than 0");

        }

        [Fact(DisplayName = "Create Product With Stock Lower Than 0")]
        public void CreateProduct_WithStockLessThanZero_DomainExceptionStockBelowZero()
        {
            //princípio AAA
            Action action = () => new Product(2, "Product Name", "Product Description", 10.9m, -1, "Product Image");
            action.Should()
                .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Stock invalid. It has to be higher than 0");

        }

        [Fact(DisplayName = "Create Product With Image Name Has More Than 250 Characters")]
        public void CreateProduct_WithImageNameTooBig_DomainExceptionImageNameTooBig()
        {
            //princípio AAA
            Action action = () => new Product(2, "Product Name", "Product Description", 10.9m, 1,
                "Image Name is to Big ggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggg");
            action.Should()
                .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Image name invalid. It can't trespass 250 characters");

        }

        [Fact(DisplayName = "Create Product With Image Name Null NoNull Reference Exception")]
        public void CreateProduct_WithNullImageName_NoNullReferenceException()
        {
            //princípio AAA
            Action action = () => new Product(2, "Product Name", "Product Description", 10.9m, 1, null);
            action.Should().NotThrow<NullReferenceException>();
        }

        [Fact(DisplayName = "Create Product With Image Name Null")]
        public void CreateProduct_WithNullImageName_ResultObjectValidState()
        {
            //princípio AAA
            Action action = () => new Product(2, "Product Name", "Product Description", 10.9m, 1, null);
            action.Should()
                .NotThrow<CleanArchMvc.Domain.Validation.DomainExceptionValidation>();

        }

        //another way to do unit test with parameter
        [Theory(DisplayName = "Create Product with Negative Value")] //used because we are using parameters in method test
        [InlineData(-5)] //will be used by value parameter
        public void CreateProduct_WithInvalidStockValue_DomainExceptionNegativeValue(int value)
        {
            //princípio AAA
            Action action = () => new Product(1, "Product Name", "Product Description", 10.9m, value, "Product Image");
            action.Should()
                .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Stock invalid. It has to be higher than 0");

        }

    }
}

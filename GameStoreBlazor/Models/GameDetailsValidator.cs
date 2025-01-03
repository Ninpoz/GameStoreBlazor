using FluentValidation;

namespace GameStoreBlazor.Models

{
    public class GameDetailsValidator : AbstractValidator<GameDetails>
    {
        public GameDetailsValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name is required.")
                .MaximumLength(100).WithMessage("Name cannot exceed 100 characters.");

            RuleFor(x => x.GenreId)
                .NotEmpty().WithMessage("Genre is required.");

            RuleFor(x => x.Price)
                .GreaterThan(0).WithMessage("Price must be greater than 0.");

            RuleFor(x => x.ReleaseDate)
                .LessThanOrEqualTo(DateOnly.FromDateTime(DateTime.Now))
                .WithMessage("Release date cannot be in the future.");
        }
    }
}

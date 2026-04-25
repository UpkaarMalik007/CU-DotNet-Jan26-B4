using FluentValidation;
using Microsoft.CodeAnalysis.FlowAnalysis.DataFlow;
using TicketBookingSystem.TripService.DTOs;

namespace TicketBookingSystem.TripService.Validatiors
{
    public class TripRequestValidator : AbstractValidator<CreateTripDto>
    {
        public TripRequestValidator()
        {
            RuleFor(x => x.Heading).NotEmpty().WithMessage("Heading should not be empty");
            RuleFor(x => x.ShipName).NotEmpty().WithMessage("ShipName should not be empty");
            RuleFor(x => x.Price).GreaterThan(30000).LessThan(200000).NotEmpty().WithMessage("Price should be in limit");
        }
        
    }
}

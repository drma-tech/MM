﻿using FluentValidation;

namespace MM.Shared.Models.Auth.Core;

public class ClientePrincipalValidation : AbstractValidator<ClientePrincipal>
{
    public ClientePrincipalValidation()
    {
        RuleFor(x => x.UserId)
            .NotEmpty();

        RuleFor(x => x.IdentityProvider)
            .NotEmpty();

        RuleFor(x => x.UserDetails)
            .NotEmpty();

        RuleFor(x => x.UserRoles)
            .NotEmpty();

        RuleFor(x => x.Email)
            .NotEmpty()
            .EmailAddress();
    }
}
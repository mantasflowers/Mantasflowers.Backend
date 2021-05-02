﻿using Mantasflowers.Contracts.Payment.Request;
using Mantasflowers.Contracts.Payment.Response;
using System.Threading.Tasks;

namespace Mantasflowers.Services.Services.Payment
{
    public interface IPaymentService
    {
        Task<PostCreateCheckoutSessionResponse> CreateCheckoutSession(PostCreateCheckoutSessionRequest request);
    }
}
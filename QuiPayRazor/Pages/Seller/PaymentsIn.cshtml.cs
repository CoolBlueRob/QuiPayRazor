using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.OAuth.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using QuiPayRazor.Data;
using QuiPayRazor.Logic.Interfaces;
using QuiPayRazor.Models;

namespace QuiPayRazor.Pages.Seller
{
    public class PaymentVM
    {

    }

    public class AccountVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Currency Currency { get; set; }
        public List<PaymentVM> PaymentsToAccount { get; set; }
    }

    public class SellerVM
    {
        public List<AccountVM> Accounts { get; set; }
    }

    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Add as many of these lines as you need to map your objects
            //CreateMap<User, UserDto>();
            //CreateMap<UserDto, User>();
        }
    }

    public class PaymentsInModel : PageModel
    {
        private readonly QuiPayRazorContext _context;

        private ILogger _logger;

        private readonly IMapper _mapper;

        [BindProperty]
        public Member Member { get; set; }

        public PaymentsInModel(ILogger<PaymentsInModel> logger, IMapper mapper, QuiPayRazorContext context)
        {
            _logger = logger;
            _mapper = mapper;
            _context = context;
        }

        public void OnGet(int memberId)
        {
            //var Member = _context.Member.Find(memberId);
            var query = _context.Member.Include(m => m.Accounts);
            var list = query.ToList();
            var Member = query.FirstOrDefault(m => m.Id == memberId);
    
            if ( Member == null)
            {
                _logger.LogError("PaymentInModel.OnGet Member is null");
            }
        }
    }
}

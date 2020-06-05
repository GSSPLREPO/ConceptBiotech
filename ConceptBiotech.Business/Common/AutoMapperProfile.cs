using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConceptBiotech.Data;
using ConceptBiotech.UIEntity;

namespace ConceptBiotech.Business
{
    public class AutoMapperProfile : Profile
    {
        public static void Initialize()
        {
            Mapper.Initialize(cfg =>
            {

                cfg.CreateMap<Token, TokenUI>()
                    .ForMember(tokui => tokui.UIDN, src => src.MapFrom(tok => tok.PK_Id))
                    .ForMember(tokui => tokui.CDt, src => src.MapFrom(tok => tok.CreatedDate))
                    .ForMember(tokui => tokui.MDt, src => src.MapFrom(tok => tok.ModifiedDate))
                    .ForMember(tokui => tokui.CBy, src => src.MapFrom(tok => tok.CreatedBy))
                    .ForMember(tokui => tokui.MBy, src => src.MapFrom(tok => tok.ModifiedBy))
                    .ForMember(tokui => tokui.St, src => src.MapFrom(tok => tok.Status))
                    .ForMember(tokui => tokui.UI, src => src.MapFrom(tok => tok.UserId))
                    .ForMember(tokui => tokui.UT, src => src.MapFrom(tok => tok.UserType))
                    .ForMember(tokui => tokui.AT, src => src.MapFrom(tok => tok.AuthToken))
                    .ForMember(tokui => tokui.IsOn, src => src.MapFrom(tok => tok.IssuedOn))
                    .ForMember(tokui => tokui.ExOn, src => src.MapFrom(tok => tok.ExpiresOn))
                    .ForMember(tokui => tokui.UN, src => src.MapFrom(tok => tok.UserName))
                    .ReverseMap();
                //cfg.CreateMap<TokenUI, Token>();

                cfg.CreateMap<User, UserUI>()
                    
                    .ForMember(userui => userui.UIDN, src => src.MapFrom(user => user.PK_Id))
                    .ForMember(userui => userui.CDt, src => src.MapFrom(user => user.CreatedDate))
                    .ForMember(userui => userui.MDt, src => src.MapFrom(user => user.ModifiedDate))
                    .ForMember(userui => userui.CBy, src => src.MapFrom(user => user.CreatedBy))
                    .ForMember(userui => userui.MBy, src => src.MapFrom(user => user.ModifiedBy))
                    .ForMember(userui => userui.St, src => src.MapFrom(user => user.Status))
                    .ForMember(userui => userui.UN, src => src.MapFrom(user => user.UserName))
                    .ForMember(userui => userui.FN, src => src.MapFrom(user => user.FirstName))
                    .ForMember(userui => userui.MN, src => src.MapFrom(user => user.MiddleName))
                    .ForMember(userui => userui.LN, src => src.MapFrom(user => user.LastName))
                    .ForMember(userui => userui.Pwd, src => src.MapFrom(user => user.Password))
                    .ForMember(userui => userui.Eml, src => src.MapFrom(user => user.Email))
                    .ForMember(userui => userui.Mo, src => src.MapFrom(user => user.Mobile))
                    .ForMember(userui => userui.Addr1, src => src.MapFrom(user => user.Address1))
                    .ForMember(userui => userui.Ct, src => src.MapFrom(user => user.City))
                    .ForMember(userui => userui.Ste, src => src.MapFrom(user => user.State))
                    .ForMember(userui => userui.Ctr, src => src.MapFrom(user => user.Country))
                    .ForMember(userui => userui.PC, src => src.MapFrom(user => user.PromotionCode))
                    .ForMember(userui => userui.UT, src => src.MapFrom(user => user.UserType)).ReverseMap();
                //properties:\r\nUN\r\nFN\r\nMN\r\nLN\r\nPwd\r\nEml\r\nMo\r\nAddr1\r\nCt\r\nSte\r\nCtr\r\nPC\r\nUT\r\nUIDN\r\nCDt\r\nMDt\r\nCBy\r\nMBy\r\nSt\r\n"}

                //cfg.CreateMap<User, UserUI>()
                //    .ForMember(userui => userui.UIDN, src => src.MapFrom(user => user.PK_Id))
                //    .ForMember(userui => userui.CDt, src => src.MapFrom(user => user.CreatedDate))
                //    .ForMember(userui => userui.MDt, src => src.MapFrom(user => user.ModifiedDate))
                //    .ForMember(userui => userui.CBy, src => src.MapFrom(user => user.CreatedBy))
                //    .ForMember(userui => userui.MBy, src => src.MapFrom(user => user.ModifiedBy))
                //    .ForMember(userui => userui.St, src => src.MapFrom(user => user.Status))
                //    .ForMember(userui => userui.UN, src => src.MapFrom(user => user.UserName))
                //    .ForMember(userui => userui.FN, src => src.MapFrom(user => user.FirstName))
                //    .ForMember(userui => userui.LN, src => src.MapFrom(user => user.LastName))
                //    .ForMember(userui => userui.Pwd, src => src.MapFrom(user => user.Password))
                //    .ForMember(userui => userui.Eml, src => src.MapFrom(user => user.Email))
                //    .ForMember(userui => userui.Mo, src => src.MapFrom(user => user.Mobile))
                //    .ForMember(userui => userui.Addr1, src => src.MapFrom(user => user.Address1))
                //    .ForMember(userui => userui.Ct, src => src.MapFrom(user => user.City))
                //    .ForMember(userui => userui.Ste, src => src.MapFrom(user => user.State))
                //    .ForMember(userui => userui.Ctr, src => src.MapFrom(user => user.Country))
                //    .ForMember(userui => userui.PC, src => src.MapFrom(user => user.PromotionCode))
                //    .ForMember(userui => userui.UT, src => src.MapFrom(user => user.UserType)).ReverseMap();

                cfg.CreateMap<ProductMaster, ProductMasterUI>()
                   .ForMember(Productui => Productui.UIDN, src => src.MapFrom(Product => Product.PK_Id))
                   .ForMember(Productui => Productui.CDt, src => src.MapFrom(Product => Product.CreatedDate))
                   .ForMember(Productui => Productui.MDt, src => src.MapFrom(Product => Product.ModifiedDate))
                   .ForMember(Productui => Productui.CBy, src => src.MapFrom(Product => Product.CreatedBy))
                   .ForMember(Productui => Productui.MBy, src => src.MapFrom(Product => Product.ModifiedBy))
                   .ForMember(Productui => Productui.St, src => src.MapFrom(Product => Product.Status))
                   .ForMember(Productui => Productui.PN, src => src.MapFrom(Product => Product.ProductName))
                   .ForMember(Productui => Productui.Code, src => src.MapFrom(Product => Product.Code))
                   .ForMember(Productui => Productui.SR, src => src.MapFrom(Product => Product.SellingRate))
                   .ForMember(Productui => Productui.PR, src => src.MapFrom(Product => Product.PurchaseRate))
                   .ForMember(Productui => Productui.UN, src => src.MapFrom(Product => Product.UnitName))
                   .ForMember(Productui => Productui.Desc, src => src.MapFrom(Product => Product.Description))
                   .ForMember(Productui => Productui.Image, src => src.MapFrom(Product => Product.ImagePath))
                   .ReverseMap();
                //cfg.CreateMap<UserUI, User>();

                cfg.CreateMap<Order, OrderUI>()
                .ForMember(vmui => vmui.UIDN, src => src.MapFrom(vm => vm.PK_Id))
                    .ForMember(vmui => vmui.CDt, src => src.MapFrom(vm => vm.CreatedDate))
                    .ForMember(vmui => vmui.MDt, src => src.MapFrom(vm => vm.ModifiedDate))
                    .ForMember(vmui => vmui.CBy, src => src.MapFrom(vm => vm.CreatedBy))
                    .ForMember(vmui => vmui.MBy, src => src.MapFrom(vm => vm.ModifiedBy))
                    .ForMember(vmui => vmui.St, src => src.MapFrom(vm => vm.Status))
                    .ForMember(vmui => vmui.ONo, src => src.MapFrom(vm => vm.OrderNo))
                    .ForMember(vmui => vmui.ODt, src => src.MapFrom(vm => vm.OrderDate))
                    .ForMember(vmui => vmui.TAmt, src => src.MapFrom(vm => vm.TotalAmount))
                    .ForMember(vmui => vmui.Desc, src => src.MapFrom(vm => vm.Description))
                    .ForMember(vmui => vmui.ODet, src => src.MapFrom(vm => vm.OrderDetails))
                    .ForMember(vmui => vmui.UserId, src => src.MapFrom(vm => vm.UserId))
                    //.ForMember(vmui => vmui.bankTr, src => src.MapFrom(vm => vm.bankTransactions))
                    .ReverseMap();

                cfg.CreateMap<OrderDetail, OrderDetailUI>()
                  .ForMember(vmui => vmui.PId, src => src.MapFrom(vm => vm.ProductId))
                  .ForMember(vmui => vmui.Qty, src => src.MapFrom(vm => vm.Quantity))
                  .ForMember(vmui => vmui.Rt, src => src.MapFrom(vm => vm.Rate))
                  .ReverseMap();
            }
            );
        }
    }
}

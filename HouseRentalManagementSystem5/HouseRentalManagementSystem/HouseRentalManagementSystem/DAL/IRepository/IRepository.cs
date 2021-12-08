using HouseRentalManagementSystem.UserViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HouseRentalManagementSystem.IRepository
{
    public interface IBuildingRepository
    {
        IEnumerable<ApartmentBuildingViewModel> GetAll();
        ApartmentBuildingViewModel GetById(int id);
        void Insert(ApartmentBuildingViewModel e);
        void Update(ApartmentBuildingViewModel e);
        void Delete(int id);
        void Save();
    }
    public interface IApartmentRepository
    {
        IEnumerable<ApartmentViewModel> GetAll();
        IEnumerable<ApartmentViewModel> GetByBuildingId(int id);
        ApartmentViewModel GetById(int id);
        ApartmentViewModel Insert(ApartmentViewModel e);
        ApartmentViewModel Update(ApartmentViewModel e);
        ApartmentViewModel Delete(int id);
        void Save();
    }
    public interface IApartmentTypeRepository
    {
        IEnumerable<ApartmentTypeViewModel> GetAll();
        ApartmentTypeViewModel GetById(int id);
        void Insert(ApartmentTypeViewModel e);
        void Update(ApartmentTypeViewModel e);
        void Delete(int id);
        void Save();
    }
    public interface IApartmentImageRepository
    {
        IEnumerable<ApartmentImageViewModel> GetAll();
        IEnumerable<ApartmentImageViewModel> GetAllByApartmentId(int id);
        ApartmentImageViewModel GetById(int id);
        void Insert(ApartmentImageViewModel e);
        void Update(ApartmentImageViewModel e);
        void Delete(int id);
        void Save();
    }
    public interface ITenantRepository
    {
        IEnumerable<TenantViewModel> GetAll();
        TenantViewModel GetById(int id);
        void Insert(TenantViewModel e);
        void Update(TenantViewModel e);
        void Delete(int id);
        void Save();
    }

    public interface IApartmentBookingRepository
    {
        IEnumerable<ApartmentBookingViewModel> GetAll();
        ApartmentBookingViewModel GetById(int id);
        ApartmentBookingViewModel Insert(ApartmentBookingViewModel e);
        ApartmentBookingViewModel Update(ApartmentBookingViewModel e);
        ApartmentBookingViewModel Delete(int id);
        void Save();
    }

    public interface IBookingStatusRepository
    {
        IEnumerable<BookingStatusViewModel> GetAll();
        BookingStatusViewModel GetById(int id);
        void Insert(BookingStatusViewModel e);
        void Update(BookingStatusViewModel e);
        void Delete(int id);
        void Save();
    }
    public interface IApartmentFacilityRepository
    {
        IEnumerable<ApartmentFacilityViewModel> GetAll();
        ApartmentFacilityViewModel GetById(int id);
        void Insert(ApartmentFacilityViewModel e);
        void Update(ApartmentFacilityViewModel e);
        void Delete(int id);
        void Save();
    }
    public interface IApartmentWiseFacilityRepository
    {
        IEnumerable<ApartmentWiseFacilityViewModel> GetAll();
        IEnumerable<ApartmentWiseFacilityViewModel> GetAllByApartmentId(int id);
        ApartmentWiseFacilityViewModel GetById(int id);
        void Insert(ApartmentWiseFacilityViewModel e);
        void Update(ApartmentWiseFacilityViewModel e);
        void Delete(int id);
        void Save();
    }
    public interface IPaymentTypeRepository
    {
        IEnumerable<PaymentTypeViewModel> GetAll();
        PaymentTypeViewModel GetById(int id);
        void Insert(PaymentTypeViewModel e);
        void Update(PaymentTypeViewModel e);
        void Delete(int id);
        void Save();
    }
    public interface IViewUnitStatusRepository
    {
        IEnumerable<ViewUnitStatusViewModel> GetAll();
        ViewUnitStatusViewModel GetViewUnitStatusByBookingId(int id);
        ViewUnitStatusViewModel GetById(int id);
        void Insert(ViewUnitStatusViewModel e);
        void Update(ViewUnitStatusViewModel e);
        void Delete(int id);
        void Save();
    }

    public interface IBookingPaymentRepository
    {
        IEnumerable<BookingPaymentViewModel> GetAll();
        BookingPaymentViewModel GetBookingPaymentByBookingId(int id);
        BookingPaymentViewModel GetById(int id);
        void Insert(BookingPaymentViewModel e);
        void Update(BookingPaymentViewModel e);
        void Delete(int id);
        void Save();
    }

    public interface ISecurityDepositRepository
    {
        IEnumerable<SecurityDepositViewModel> GetAll();
        SecurityDepositViewModel GetSecurityDipositeByBookingId(int id);
        SecurityDepositViewModel GetById(int id);
        void Insert(SecurityDepositViewModel e);
        void Update(SecurityDepositViewModel e);
        void Delete(int id);
        void Save();
    }
}

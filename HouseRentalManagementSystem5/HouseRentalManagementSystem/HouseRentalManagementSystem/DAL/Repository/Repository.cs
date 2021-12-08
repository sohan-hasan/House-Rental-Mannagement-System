using HouseRentalManagementSystem.IRepository;
using HouseRentalManagementSystem.Models;
using HouseRentalManagementSystem.UserViewModels;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace HouseRentalManagementSystem.Repository
{
    public class BuildingRepository : IBuildingRepository
    {
        private readonly HouseRentalManagementSystemContext dbObj;
        public BuildingRepository(HouseRentalManagementSystemContext _dbObj)
        {
            dbObj = _dbObj;
        }

        public IEnumerable<ApartmentBuildingViewModel> GetAll()
        {
            IEnumerable<ApartmentBuildingViewModel> listOfBuilding = dbObj.ApartmentBuildings.Select(e => new ApartmentBuildingViewModel
            {
                BuildingId = e.BuildingId,
                BuildingShortName = e.BuildingShortName,
                BuildingFullName = e.BuildingFullName,
                BuildingDescription = e.BuildingDescription,
                BuildingAddress = e.BuildingAddress,
                BuildingManager = e.BuildingManager,
                BuildingPhone = e.BuildingPhone,
                OtherBuildingDetails = e.OtherBuildingDetails,
                ImageName = e.ImageName
            }).ToList();
            return listOfBuilding;
        }

        public ApartmentBuildingViewModel GetById(int id)
        {
            ApartmentBuilding e = dbObj.ApartmentBuildings.AsNoTracking().SingleOrDefault(e => e.BuildingId == id);
            ApartmentBuildingViewModel building = new ApartmentBuildingViewModel
            {
                BuildingId = e.BuildingId,
                BuildingShortName = e.BuildingShortName,
                BuildingFullName = e.BuildingFullName,
                BuildingDescription = e.BuildingDescription,
                BuildingAddress = e.BuildingAddress,
                BuildingManager = e.BuildingManager,
                BuildingPhone = e.BuildingPhone,
                OtherBuildingDetails = e.OtherBuildingDetails,
                ImageName = e.ImageName
            };
            return building;
        }

        public void Insert(ApartmentBuildingViewModel e)
        {
            ApartmentBuilding obj = new ApartmentBuilding()
            {
                BuildingId = e.BuildingId,
                BuildingShortName = e.BuildingShortName,
                BuildingFullName = e.BuildingFullName,
                BuildingDescription = e.BuildingDescription,
                BuildingAddress = e.BuildingAddress,
                BuildingManager = e.BuildingManager,
                BuildingPhone = e.BuildingPhone,
                OtherBuildingDetails = e.OtherBuildingDetails,
                ImageName = e.ImageName
            };
            dbObj.ApartmentBuildings.Add(obj);
            Save();
        }

        public void Update(ApartmentBuildingViewModel e)
        {
            ApartmentBuilding obj = new ApartmentBuilding()
            {
                BuildingId = e.BuildingId,
                BuildingShortName = e.BuildingShortName,
                BuildingFullName = e.BuildingFullName,
                BuildingDescription = e.BuildingDescription,
                BuildingAddress = e.BuildingAddress,
                BuildingManager = e.BuildingManager,
                BuildingPhone = e.BuildingPhone,
                OtherBuildingDetails = e.OtherBuildingDetails,
                ImageName = e.ImageName
            };
            dbObj.Entry(obj).State = EntityState.Modified;
            Save();
        }
        public void Delete(int id)
        {
            ApartmentBuilding building = dbObj.ApartmentBuildings.Find(id);
            dbObj.ApartmentBuildings.Remove(building);
            Save();
        }
        public void Save()
        {
            dbObj.SaveChanges();
        }

    }
    public class ApartmentRepository : IApartmentRepository
    {
        private readonly HouseRentalManagementSystemContext dbObj;
        public ApartmentRepository(HouseRentalManagementSystemContext _dbObj)
        {
            dbObj = _dbObj;
        }
        public IEnumerable<ApartmentViewModel> GetAll()
        {
            IEnumerable<ApartmentViewModel> listOfApartment = dbObj.Apartments.Select(e => new ApartmentViewModel
            {
                AptId = e.AptId,
                BuildingId = e.BuildingId,
                AptTypeCode = e.AptTypeCode,
                ApartmentName = e.ApartmentName,
                BathroomCount = e.BathroomCount,
                BedroomCount = e.BedroomCount,
                RoomCount = e.RoomCount,
                MonthlyRent = e.MonthlyRent,
                SecurityDepositAmount = e.SecurityDepositAmount,
                OtherApartmentDetails = e.OtherApartmentDetails,
                AptTypeDescription = e.RefApartmentType.AptTypeDescription,
                BuildingShortName = e.Building.BuildingShortName,
            }).ToList();
            return listOfApartment;
        }
        public IEnumerable<ApartmentViewModel> GetByBuildingId(int id)
        {

            IEnumerable<ApartmentViewModel> listOfApartments = dbObj.Apartments.Where(a => a.BuildingId == id).Select(e => new ApartmentViewModel
            {
                AptId = e.AptId,
                BuildingId = e.BuildingId,
                AptTypeCode = e.AptTypeCode,
                ApartmentName = e.ApartmentName,
                BathroomCount = e.BathroomCount,
                BedroomCount = e.BedroomCount,
                RoomCount = e.RoomCount,
                MonthlyRent = e.MonthlyRent,
                SecurityDepositAmount = e.SecurityDepositAmount,
                OtherApartmentDetails = e.OtherApartmentDetails,
                AptTypeDescription = e.RefApartmentType.AptTypeDescription,
                BuildingShortName = e.Building.BuildingShortName,
            }).ToList();
            return listOfApartments;
        }
        public ApartmentViewModel GetById(int id)
        {
            Apartment e = dbObj.Apartments.AsNoTracking().SingleOrDefault(e => e.AptId == id);
            ApartmentViewModel apartment = new ApartmentViewModel
            {
                AptId = e.AptId,
                BuildingId = e.BuildingId,
                AptTypeCode = e.AptTypeCode,
                ApartmentName = e.ApartmentName,
                BathroomCount = e.BathroomCount,
                BedroomCount = e.BedroomCount,
                RoomCount = e.RoomCount,
                MonthlyRent = e.MonthlyRent,
                SecurityDepositAmount = e.SecurityDepositAmount,
                OtherApartmentDetails = e.OtherApartmentDetails,
            };
            return apartment;
        }

        public ApartmentViewModel Insert(ApartmentViewModel e)
        {
            Apartment obj = new Apartment()
            {
                BuildingId = e.BuildingId,
                AptTypeCode = e.AptTypeCode,
                ApartmentName = e.ApartmentName,
                BathroomCount = e.BathroomCount,
                BedroomCount = e.BedroomCount,
                RoomCount = e.RoomCount,
                MonthlyRent = e.MonthlyRent,
                SecurityDepositAmount = e.SecurityDepositAmount,
                OtherApartmentDetails = e.OtherApartmentDetails,
            };
            dbObj.Apartments.Add(obj);
            Save();
            ApartmentViewModel obj1 = new ApartmentViewModel()
            {
                AptId = obj.AptId
            };
            return obj1;
        }
        public ApartmentViewModel Update(ApartmentViewModel e)
        {
            Apartment obj = new Apartment()
            {
                AptId = e.AptId,
                BuildingId = e.BuildingId,
                AptTypeCode = e.AptTypeCode,
                ApartmentName = e.ApartmentName,
                BathroomCount = e.BathroomCount,
                BedroomCount = e.BedroomCount,
                RoomCount = e.RoomCount,
                MonthlyRent = e.MonthlyRent,
                SecurityDepositAmount = e.SecurityDepositAmount,
                OtherApartmentDetails = e.OtherApartmentDetails,
            };
            dbObj.Entry(obj).State = EntityState.Modified;
            Save();
            ApartmentViewModel obj1 = new ApartmentViewModel()
            {
                AptId = obj.AptId
            };
            return obj1;
        }
        public ApartmentViewModel Delete(int id)
        {
            ApartmentViewModel obj = GetById(id);
            Apartment apartment = dbObj.Apartments.Find(id);
            dbObj.Apartments.Remove(apartment);
            Save();
            return obj;
        }

        public void Save()
        {
            dbObj.SaveChanges();
        }
    }
    public class ApartmentTypeRepository : IApartmentTypeRepository
    {
        private readonly HouseRentalManagementSystemContext dbObj;
        public ApartmentTypeRepository(HouseRentalManagementSystemContext _dbObj)
        {
            dbObj = _dbObj;
        }
        public IEnumerable<ApartmentTypeViewModel> GetAll()
        {
            int indexNumber = 0;
            IEnumerable<ApartmentTypeViewModel> listOfApartment = dbObj.RefApartmentTypes.Select(e => new ApartmentTypeViewModel
            {
                AptTypeCode = e.AptTypeCode,
                AptTypeDescription = e.AptTypeDescription,
            }).ToList();
            foreach (var item in listOfApartment)
            {
                item.SirialNumber = indexNumber += 1;
            }
            return listOfApartment;
        }

        public ApartmentTypeViewModel GetById(int id)
        {
            RefApartmentType e = dbObj.RefApartmentTypes.AsNoTracking().SingleOrDefault(e => e.AptTypeCode == id);
            ApartmentTypeViewModel apartment = new ApartmentTypeViewModel
            {
                AptTypeCode = e.AptTypeCode,
                AptTypeDescription = e.AptTypeDescription,
            };
            return apartment;
        }

        public void Insert(ApartmentTypeViewModel e)
        {
            RefApartmentType obj = new RefApartmentType()
            {
                AptTypeCode = e.AptTypeCode,
                AptTypeDescription = e.AptTypeDescription,
            };
            dbObj.RefApartmentTypes.Add(obj);
            Save();
        }
        public void Update(ApartmentTypeViewModel e)
        {
            RefApartmentType obj = new RefApartmentType()
            {
                AptTypeCode = e.AptTypeCode,
                AptTypeDescription = e.AptTypeDescription,
            };
            dbObj.Entry(obj).State = EntityState.Modified;
            Save();
        }
        public void Delete(int id)
        {
            RefApartmentType type = dbObj.RefApartmentTypes.Find(id);
            dbObj.RefApartmentTypes.Remove(type);
            Save();
        }

        public void Save()
        {
            dbObj.SaveChanges();
        }
    }
    public class ApartmentImageRepository : IApartmentImageRepository
    {
        private readonly HouseRentalManagementSystemContext dbObj;
        public ApartmentImageRepository(HouseRentalManagementSystemContext _dbObj)
        {
            dbObj = _dbObj;
        }
        public IEnumerable<ApartmentImageViewModel> GetAll()
        {
            IEnumerable<ApartmentImageViewModel> listOfApartment = dbObj.ApartmentImages.Select(e => new ApartmentImageViewModel
            {
                ImageId = e.ImageId,
                ImageName = e.ImageName,
                AptId = e.AptId,
            }).ToList();
            return listOfApartment;
        }
        public IEnumerable<ApartmentImageViewModel> GetAllByApartmentId(int id)
        {
            IEnumerable<ApartmentImageViewModel> listOfImages = dbObj.ApartmentImages.Where(a => a.AptId == id).Select(e => new ApartmentImageViewModel
            {
                ImageId = e.ImageId,
                ImageName = e.ImageName,
                AptId = e.AptId,
            }).ToList();
            return listOfImages;
        }
        public ApartmentImageViewModel GetById(int id)
        {
            ApartmentImage e = dbObj.ApartmentImages.AsNoTracking().SingleOrDefault(e => e.ImageId == id);
            ApartmentImageViewModel image = new ApartmentImageViewModel
            {
                ImageId = e.ImageId,
                ImageName = e.ImageName,
                AptId = e.AptId,
            };
            return image;
        }

        public void Insert(ApartmentImageViewModel e)
        {
            ApartmentImage obj = new ApartmentImage()
            {
                ImageName = e.ImageName,
                AptId = e.AptId,
            };
            dbObj.ApartmentImages.Add(obj);
            Save();
        }

        public void Update(ApartmentImageViewModel e)
        {
            ApartmentImage obj = new ApartmentImage()
            {
                ImageId = e.ImageId,
                ImageName = e.ImageName,
                AptId = e.AptId,
            };
            dbObj.Entry(obj).State = EntityState.Modified;
            Save();
        }
        public void Delete(int id)
        {
            ApartmentImage image = dbObj.ApartmentImages.AsNoTracking().SingleOrDefault(e => e.ImageId == id);
            dbObj.ApartmentImages.Remove(image);
            Save();

        }
        public void Save()
        {
            dbObj.SaveChanges();
        }
    }
    public class TenanRepository : ITenantRepository
    {
        private readonly HouseRentalManagementSystemContext dbObj;
        public TenanRepository(HouseRentalManagementSystemContext _dbObj)
        {
            dbObj = _dbObj;
        }

        public IEnumerable<TenantViewModel> GetAll()
        {
            IEnumerable<TenantViewModel> listOfTenant = dbObj.Tenantes.Select(e => new TenantViewModel
            {
                TenantId = e.TenantId,
                TenantFirstName = e.TenantFirstName,
                TenantLastName = e.TenantLastName,
                Phone=e.Phone,
                Email=e.Email,
                TenantFullName = e.TenantFirstName + " " + e.TenantLastName,
                DateOfBirth = e.DateOfBirth,
                GenderCode = e.GenderCode,
                OtherTenantDetails = e.OtherTenantDetails,
                ImageName = e.ImageName,
                ImageFullPath=e.ImageFullPath,
            }).ToList();
            return listOfTenant;

        }


        public TenantViewModel GetById(int id)
        {
            Tenant e = dbObj.Tenantes.AsNoTracking().SingleOrDefault(e => e.TenantId == id);
            TenantViewModel tenant = new TenantViewModel
            {
                TenantId = e.TenantId,
                TenantFirstName = e.TenantFirstName,
                TenantLastName = e.TenantLastName,
                Phone = e.Phone,
                Email = e.Email,
                DateOfBirth = e.DateOfBirth,
                GenderCode = e.GenderCode,
                OtherTenantDetails = e.OtherTenantDetails,
                ImageName = e.ImageName,
                ImageFullPath = e.ImageFullPath,
            };
            return tenant;
        }

        public void Insert(TenantViewModel e)
        {
            Tenant obj = new Tenant()
            {
                TenantId = e.TenantId,
                TenantFirstName = e.TenantFirstName,
                TenantLastName = e.TenantLastName,
                Phone = e.Phone,
                Email = e.Email,
                DateOfBirth = e.DateOfBirth,
                GenderCode = e.GenderCode,
                OtherTenantDetails = e.OtherTenantDetails,
                ImageName = e.ImageName,
                ImageFullPath = e.ImageFullPath,
            };
            dbObj.Tenantes.Add(obj);
            Save();
        }


        public void Update(TenantViewModel e)
        {
            Tenant obj = new Tenant()
            {
                TenantId = e.TenantId,
                TenantFirstName = e.TenantFirstName,
                TenantLastName = e.TenantLastName,
                Phone = e.Phone,
                Email = e.Email,
                DateOfBirth = e.DateOfBirth,
                GenderCode = e.GenderCode,
                OtherTenantDetails = e.OtherTenantDetails,
                ImageName = e.ImageName,
                ImageFullPath = e.ImageFullPath,
            };
            dbObj.Entry(obj).State = EntityState.Modified;
            Save();
        }
        public void Delete(int id)
        {
            Tenant tenant = dbObj.Tenantes.Find(id);
            dbObj.Tenantes.Remove(tenant);
            Save();
        }
        public void Save()
        {
            dbObj.SaveChanges();
        }
    }
    public class ApartmentBookingRepository : IApartmentBookingRepository
    {
        private readonly HouseRentalManagementSystemContext dbObj;
        public ApartmentBookingRepository(HouseRentalManagementSystemContext _dbObj)
        {
            dbObj = _dbObj;
        }

        public IEnumerable<ApartmentBookingViewModel> GetAll()
        {
            IEnumerable<ApartmentBookingViewModel> listOfBooking = dbObj.ApartmentBookings.Select(e => new ApartmentBookingViewModel
            {
                AptBookingId = e.AptBookingId,
                BuildingId = e.BuildingId,
                BuildingShortName = e.ApartmentBuilding.BuildingShortName,
                AptId = e.AptId,
                ApartmentName = e.Apartment.ApartmentName,
                TenantId = e.TenantId,
                TenantFullName = e.Tenant.TenantFirstName + " " + e.Tenant.TenantLastName,
                BookingStatusCode = e.BookingStatusCode,
                BookingStatusDescription = e.RefBookingStatus.BookingStatusDescription,
                BookingStartDate = e.BookingStartDate,
                BookingEndDate = e.BookingEndDate,
                OtherBookingDetails = e.OtherBookingDetails,
            }).ToList();
            return listOfBooking;
        }

        public ApartmentBookingViewModel GetById(int id)
        {
            ApartmentBooking e = dbObj.ApartmentBookings.AsNoTracking().SingleOrDefault(e => e.AptBookingId == id);
            BookingPayment bookingPayment = dbObj.BookingPayments.AsNoTracking().SingleOrDefault(s => s.AptBookingId == id);
            Apartment apartment = dbObj.Apartments.AsNoTracking().SingleOrDefault(s => s.AptId == e.AptId);
            if (apartment!=null && bookingPayment!=null)
            {
                ApartmentBookingViewModel booking = new ApartmentBookingViewModel
                {
                    AptBookingId = e.AptBookingId,
                    BuildingId = e.BuildingId,
                    AptId = e.AptId,
                    TenantId = e.TenantId,
                    BookingStatusCode = e.BookingStatusCode,
                    BookingStartDate = e.BookingStartDate,
                    BookingEndDate = e.BookingEndDate,
                    OtherBookingDetails = e.OtherBookingDetails,
                    MonthlyRent=apartment.MonthlyRent,
                    SecurityDepositAmount=apartment.SecurityDepositAmount,
                    PaymentTypeId=bookingPayment.PaymentTypeId,
                };
                return booking;
            }
            else if (bookingPayment != null)
            {
                ApartmentBookingViewModel booking = new ApartmentBookingViewModel
                {
                    AptBookingId = e.AptBookingId,
                    BuildingId = e.BuildingId,
                    AptId = e.AptId,
                    TenantId = e.TenantId,
                    BookingStatusCode = e.BookingStatusCode,
                    BookingStartDate = e.BookingStartDate,
                    BookingEndDate = e.BookingEndDate,
                    OtherBookingDetails = e.OtherBookingDetails,
                    PaymentTypeId = bookingPayment.PaymentTypeId,
                };
                return booking;
            }
            else if (apartment != null)
            {
                ApartmentBookingViewModel booking = new ApartmentBookingViewModel
                {
                    AptBookingId = e.AptBookingId,
                    BuildingId = e.BuildingId,
                    AptId = e.AptId,
                    TenantId = e.TenantId,
                    BookingStatusCode = e.BookingStatusCode,
                    BookingStartDate = e.BookingStartDate,
                    BookingEndDate = e.BookingEndDate,
                    OtherBookingDetails = e.OtherBookingDetails,
                    MonthlyRent = apartment.MonthlyRent,
                    SecurityDepositAmount = apartment.SecurityDepositAmount,
                };
                return booking;
            }
            else
            {
                ApartmentBookingViewModel booking = new ApartmentBookingViewModel
                {
                    AptBookingId = e.AptBookingId,
                    BuildingId = e.BuildingId,
                    AptId = e.AptId,
                    TenantId = e.TenantId,
                    BookingStatusCode = e.BookingStatusCode,
                    BookingStartDate = e.BookingStartDate,
                    BookingEndDate = e.BookingEndDate,
                    OtherBookingDetails = e.OtherBookingDetails,
                };
                return booking;
            }
        }

        public ApartmentBookingViewModel Insert(ApartmentBookingViewModel e)
        {
            ApartmentBooking obj = new ApartmentBooking()
            {
                BuildingId = e.BuildingId,
                AptId = e.AptId,
                TenantId = e.TenantId,
                BookingStatusCode = e.BookingStatusCode,
                BookingStartDate = e.BookingStartDate,
                BookingEndDate = e.BookingEndDate,
                OtherBookingDetails = e.OtherBookingDetails,
            };
            dbObj.ApartmentBookings.Add(obj);
            Save();
            ApartmentBookingViewModel obj1 = new ApartmentBookingViewModel()
            {
                AptBookingId = obj.AptBookingId,
            };
            return obj1;
        }


        public ApartmentBookingViewModel Update(ApartmentBookingViewModel e)
        {
            ApartmentBooking obj = new ApartmentBooking()
            {
                AptBookingId = e.AptBookingId,
                BuildingId = e.BuildingId,
                AptId = e.AptId,
                TenantId = e.TenantId,
                BookingStatusCode = e.BookingStatusCode,
                BookingStartDate = e.BookingStartDate,
                BookingEndDate = e.BookingEndDate,
                OtherBookingDetails = e.OtherBookingDetails,
            };
            dbObj.Entry(obj).State = EntityState.Modified;
            Save();
            ApartmentBookingViewModel obj1 = new ApartmentBookingViewModel()
            {
                AptBookingId = obj.AptBookingId
            };
            return obj1;
        }
        public ApartmentBookingViewModel Delete(int id)
        {
            ApartmentBookingViewModel obj = GetById(id);
            ApartmentBooking booking = dbObj.ApartmentBookings.Find(id);
            dbObj.ApartmentBookings.Remove(booking);
            Save();
            return obj;
        }
        public void Save()
        {
            dbObj.SaveChanges();
        }

    }
    public class BookingStatusRepository : IBookingStatusRepository
    {
        private readonly HouseRentalManagementSystemContext dbObj;
        public BookingStatusRepository(HouseRentalManagementSystemContext _dbObj)
        {
            dbObj = _dbObj;
        }

        public IEnumerable<BookingStatusViewModel> GetAll()
        {
            int indexNumber = 0;
            IEnumerable<BookingStatusViewModel> listOfBookingStatus = dbObj.RefBookingStatuses.Select(e => new BookingStatusViewModel
            {
                BookingStatusCode = e.BookingStatusCode,
                BookingStatusDescription = e.BookingStatusDescription,
            }).ToList();
            foreach (var item in listOfBookingStatus)
            {
                item.SirialNumber = indexNumber += 1;
            }
            return listOfBookingStatus;
        }

        public BookingStatusViewModel GetById(int id)
        {
            RefBookingStatus e = dbObj.RefBookingStatuses.AsNoTracking().SingleOrDefault(e => e.BookingStatusCode == id);
            BookingStatusViewModel booking = new BookingStatusViewModel
            {
                BookingStatusCode = e.BookingStatusCode,
                BookingStatusDescription = e.BookingStatusDescription,
            };
            return booking;
        }

        public void Insert(BookingStatusViewModel e)
        {
            RefBookingStatus obj = new RefBookingStatus()
            {
                BookingStatusDescription = e.BookingStatusDescription,
            };
            dbObj.RefBookingStatuses.Add(obj);
            Save();
        }


        public void Update(BookingStatusViewModel e)
        {
            RefBookingStatus obj = new RefBookingStatus()
            {
                BookingStatusCode = e.BookingStatusCode,
                BookingStatusDescription = e.BookingStatusDescription,
            };
            dbObj.Entry(obj).State = EntityState.Modified;
            Save();
        }
        public void Delete(int id)
        {
            RefBookingStatus bookingStatus = dbObj.RefBookingStatuses.Find(id);
            dbObj.RefBookingStatuses.Remove(bookingStatus);
            Save();
        }
        public void Save()
        {
            dbObj.SaveChanges();
        }

    }
    public class ApartmentFacilityRepository : IApartmentFacilityRepository
    {
        private readonly HouseRentalManagementSystemContext dbObj;
        public ApartmentFacilityRepository(HouseRentalManagementSystemContext _dbObj)
        {
            dbObj = _dbObj;
        }

        public IEnumerable<ApartmentFacilityViewModel> GetAll()
        {
            int indexNumber = 0;
            IEnumerable<ApartmentFacilityViewModel> listOfFacility = dbObj.RefApartmentFacilities.Select(e => new ApartmentFacilityViewModel
            {
                FacilityCode = e.FacilityCode,
                FacilityDescription = e.FacilityDescription,
            }).ToList();
            foreach (var item in listOfFacility)
            {
                item.SirialNumber = indexNumber += 1;
            }
            return listOfFacility;
        }

        public ApartmentFacilityViewModel GetById(int id)
        {
            RefApartmentFacility e = dbObj.RefApartmentFacilities.AsNoTracking().SingleOrDefault(e => e.FacilityCode == id);
            ApartmentFacilityViewModel facility = new ApartmentFacilityViewModel
            {
                FacilityCode = e.FacilityCode,
                FacilityDescription = e.FacilityDescription,
            };
            return facility;
        }

        public void Insert(ApartmentFacilityViewModel e)
        {
            RefApartmentFacility obj = new RefApartmentFacility()
            {
                FacilityCode = e.FacilityCode,
                FacilityDescription = e.FacilityDescription,
            };
            dbObj.RefApartmentFacilities.Add(obj);
            Save();
        }


        public void Update(ApartmentFacilityViewModel e)
        {
            RefApartmentFacility obj = new RefApartmentFacility()
            {
                FacilityCode = e.FacilityCode,
                FacilityDescription = e.FacilityDescription,
            };
            dbObj.Entry(obj).State = EntityState.Modified;
            Save();
        }
        public void Delete(int id)
        {
            RefApartmentFacility facility = dbObj.RefApartmentFacilities.Find(id);
            dbObj.RefApartmentFacilities.Remove(facility);
            Save();
        }
        public void Save()
        {
            dbObj.SaveChanges();
        }

    }
    public class ApartmentWiseFacilityRepository : IApartmentWiseFacilityRepository
    {
        private readonly HouseRentalManagementSystemContext dbObj;
        public ApartmentWiseFacilityRepository(HouseRentalManagementSystemContext _dbObj)
        {
            dbObj = _dbObj;
        }

        public IEnumerable<ApartmentWiseFacilityViewModel> GetAll()
        {
            IEnumerable<ApartmentWiseFacilityViewModel> listOfApartmentWiseFacility = dbObj.ApartmentWiseFacilities.Select(e => new ApartmentWiseFacilityViewModel
            {
                ApartmentWiseFacilityId = e.ApartmentWiseFacilityId,
                FacilityCode = e.FacilityCode,
                AptId = e.AptId,
                IsChecked = e.IsChecked,
            }).ToList();
            return listOfApartmentWiseFacility;
        }

        public IEnumerable<ApartmentWiseFacilityViewModel> GetAllByApartmentId(int id)
        {
            IEnumerable<ApartmentWiseFacilityViewModel> listOfFacilities = dbObj.ApartmentWiseFacilities.Where(a => a.AptId == id).Select(e => new ApartmentWiseFacilityViewModel
            {
                ApartmentWiseFacilityId = e.ApartmentWiseFacilityId,
                FacilityCode = e.FacilityCode,
                AptId = e.AptId,
                IsChecked = e.IsChecked,
                FacilityDescription = e.RefApartmentFacility.FacilityDescription,
            }).ToList();
            return listOfFacilities;
        }
        public ApartmentWiseFacilityViewModel GetById(int id)
        {
            ApartmentWiseFacility e = dbObj.ApartmentWiseFacilities.AsNoTracking().SingleOrDefault(e => e.ApartmentWiseFacilityId == id);
            ApartmentWiseFacilityViewModel apartmentWiseFacility = new ApartmentWiseFacilityViewModel
            {
                ApartmentWiseFacilityId = e.ApartmentWiseFacilityId,
                FacilityCode = e.FacilityCode,
                AptId = e.AptId,
                IsChecked = e.IsChecked,
            };
            return apartmentWiseFacility;
        }

        public void Insert(ApartmentWiseFacilityViewModel e)
        {
            ApartmentWiseFacility obj = new ApartmentWiseFacility()
            {
                AptId = e.AptId,
                FacilityCode = e.FacilityCode,
                IsChecked = e.IsChecked
            };
            dbObj.ApartmentWiseFacilities.Add(obj);
            Save();
        }

        public void Update(ApartmentWiseFacilityViewModel e)
        {
            ApartmentWiseFacility obj = new ApartmentWiseFacility()
            {
                ApartmentWiseFacilityId = e.ApartmentWiseFacilityId,
                FacilityCode = e.FacilityCode,
                AptId = e.AptId,
                IsChecked = e.IsChecked,
            };
            dbObj.Entry(obj).State = EntityState.Modified;
            Save();
        }
        public void Delete(int id)
        {
            ApartmentWiseFacility obj = dbObj.ApartmentWiseFacilities.Find(id);
            dbObj.ApartmentWiseFacilities.Remove(obj);
            Save();
        }
        public void Save()
        {
            dbObj.SaveChanges();
        }
    }
    public class PaymentTypeRepository : IPaymentTypeRepository
    {
        private readonly HouseRentalManagementSystemContext dbObj;
        public PaymentTypeRepository(HouseRentalManagementSystemContext _dbObj)
        {
            dbObj = _dbObj;
        }

        public IEnumerable<PaymentTypeViewModel> GetAll()
        {
            IEnumerable<PaymentTypeViewModel> listOfPaymentType = dbObj.RefPaymentTypes.Select(e => new PaymentTypeViewModel
            {
                PaymentTypeId = e.PaymentTypeId,
                PaymentTypeDetails = e.PaymentTypeDetails,
            }).ToList();
            int indexNumber = 0;
            foreach (var item in listOfPaymentType)
            {
                item.SirialNumber = indexNumber += 1;
            }
            return listOfPaymentType;
        }
        public PaymentTypeViewModel GetById(int id)
        {
            RefPaymentType e = dbObj.RefPaymentTypes.AsNoTracking().SingleOrDefault(e => e.PaymentTypeId == id);
            PaymentTypeViewModel paymentType = new PaymentTypeViewModel
            {
                PaymentTypeId = e.PaymentTypeId,
                PaymentTypeDetails = e.PaymentTypeDetails,
            };
            return paymentType;
        }

        public void Insert(PaymentTypeViewModel e)
        {
            RefPaymentType obj = new RefPaymentType()
            {
                PaymentTypeId = e.PaymentTypeId,
                PaymentTypeDetails = e.PaymentTypeDetails,
            };
            dbObj.RefPaymentTypes.Add(obj);
            Save();
        }

        public void Update(PaymentTypeViewModel e)
        {
            RefPaymentType obj = new RefPaymentType()
            {
                PaymentTypeId = e.PaymentTypeId,
                PaymentTypeDetails = e.PaymentTypeDetails,
            };
            dbObj.Entry(obj).State = EntityState.Modified;
            Save();
        }
        public void Delete(int id)
        {
            RefPaymentType obj = dbObj.RefPaymentTypes.Find(id);
            dbObj.RefPaymentTypes.Remove(obj);
            Save();
        }
        public void Save()
        {
            dbObj.SaveChanges();
        }
    }
    public class ViewUnitStatusRepository : IViewUnitStatusRepository
    {
        private readonly HouseRentalManagementSystemContext dbObj;
        public ViewUnitStatusRepository(HouseRentalManagementSystemContext _dbObj)
        {
            dbObj = _dbObj;
        }

        public IEnumerable<ViewUnitStatusViewModel> GetAll()
        {
            IEnumerable<ViewUnitStatusViewModel> listOfUnitStatus = dbObj.ViewUnitStatuses.Select(e => new ViewUnitStatusViewModel
            {
                StatusId = e.StatusId,
                AptId=e.AptId,
                AptBookingId=e.AptBookingId,
                StatusDate=e.StatusDate,
                AvailableYn=e.AvailableYn,
            }).ToList();
            int indexNumber = 0;
            foreach (var item in listOfUnitStatus)
            {
                item.SirialNumber = indexNumber += 1;
            }
            return listOfUnitStatus;
        }

        public ViewUnitStatusViewModel GetViewUnitStatusByBookingId(int id)
        {
            ViewUnitStatus e = dbObj.ViewUnitStatuses.AsNoTracking().SingleOrDefault(e => e.AptBookingId == id);
            if (e!=null)
            {
                ViewUnitStatusViewModel unitStatus = new ViewUnitStatusViewModel
                {
                    StatusId = e.StatusId,
                    AptId = e.AptId,
                    AptBookingId = e.AptBookingId,
                    StatusDate = e.StatusDate,
                    AvailableYn = e.AvailableYn,
                };
                return unitStatus;
            }
            else
            {
                return null;
            }
        }
        public ViewUnitStatusViewModel GetById(int id)
        {
            ViewUnitStatus e = dbObj.ViewUnitStatuses.AsNoTracking().SingleOrDefault(e => e.StatusId == id);
            ViewUnitStatusViewModel unitStatus = new ViewUnitStatusViewModel
            {
                StatusId = e.StatusId,
                AptId = e.AptId,
                AptBookingId = e.AptBookingId,
                StatusDate = e.StatusDate,
                AvailableYn = e.AvailableYn,
            };
            return unitStatus;
        }

        public void Insert(ViewUnitStatusViewModel e)
        {
            ViewUnitStatus obj = new ViewUnitStatus()
            {
                StatusId = e.StatusId,
                AptId = e.AptId,
                AptBookingId = e.AptBookingId,
                StatusDate = e.StatusDate,
                AvailableYn = e.AvailableYn,
            };
            dbObj.ViewUnitStatuses.Add(obj);
            Save();
        }

        public void Update(ViewUnitStatusViewModel e)
        {
            ViewUnitStatus obj = new ViewUnitStatus()
            {
                StatusId = e.StatusId,
                AptId = e.AptId,
                AptBookingId = e.AptBookingId,
                StatusDate = e.StatusDate,
                AvailableYn = e.AvailableYn,
            };
            dbObj.Entry(obj).State = EntityState.Modified;
            Save();
        }
        public void Delete(int id)
        {
            ViewUnitStatus obj = dbObj.ViewUnitStatuses.Find(id);
            dbObj.ViewUnitStatuses.Remove(obj);
            Save();
        }
        public void Save()
        {
            dbObj.SaveChanges();
        }

    }
    public class BookingPaymentRepository : IBookingPaymentRepository
    {
        private readonly HouseRentalManagementSystemContext dbObj;
        public BookingPaymentRepository(HouseRentalManagementSystemContext _dbObj)
        {
            dbObj = _dbObj;
        }

        public IEnumerable<BookingPaymentViewModel> GetAll()
        {
            IEnumerable<BookingPaymentViewModel> listOfBookingPayment = dbObj.BookingPayments.Select(e => new BookingPaymentViewModel
            {
                PaymentId = e.PaymentId,
                PaymentTypeId = e.PaymentTypeId,
                PaymentDate = e.PaymentDate,
                PaymemtAmount = e.PaymemtAmount,
                AptBookingId = e.AptBookingId,
            }).ToList();
            int indexNumber = 0;
            foreach (var item in listOfBookingPayment)
            {
                item.SirialNumber = indexNumber += 1;
            }
            return listOfBookingPayment;
        }

        public BookingPaymentViewModel GetBookingPaymentByBookingId(int id)
        {
            BookingPayment e = dbObj.BookingPayments.AsNoTracking().SingleOrDefault(e => e.AptBookingId == id);
            if (e!=null)
            {
                BookingPaymentViewModel bookingPayment = new BookingPaymentViewModel
                {
                    PaymentId = e.PaymentId,
                    PaymentTypeId = e.PaymentTypeId,
                    PaymentDate = e.PaymentDate,
                    PaymemtAmount = e.PaymemtAmount,
                    AptBookingId = e.AptBookingId,
                };
                return bookingPayment;
            }
            else
            {
                return null;
            }
        }
        public BookingPaymentViewModel GetById(int id)
        {
            BookingPayment e = dbObj.BookingPayments.AsNoTracking().SingleOrDefault(e => e.PaymentId == id);
            BookingPaymentViewModel bookingPayment = new BookingPaymentViewModel
            {
                PaymentId = e.PaymentId,
                PaymentTypeId = e.PaymentTypeId,
                PaymentDate = e.PaymentDate,
                PaymemtAmount = e.PaymemtAmount,
                AptBookingId = e.AptBookingId,
            };
            return bookingPayment;
        }

        public void Insert(BookingPaymentViewModel e)
        {
            BookingPayment obj = new BookingPayment()
            {
                PaymentId = e.PaymentId,
                PaymentTypeId = e.PaymentTypeId,
                PaymentDate = e.PaymentDate,
                PaymemtAmount = e.PaymemtAmount,
                AptBookingId = e.AptBookingId,
            };
            dbObj.BookingPayments.Add(obj);
            Save();
        }

        public void Update(BookingPaymentViewModel e)
        {
            BookingPayment obj = new BookingPayment()
            {
                PaymentId = e.PaymentId,
                PaymentTypeId = e.PaymentTypeId,
                PaymentDate = e.PaymentDate,
                PaymemtAmount = e.PaymemtAmount,
                AptBookingId = e.AptBookingId,
            };
            dbObj.Entry(obj).State = EntityState.Modified;
            Save();
        }
        public void Delete(int id)
        {
            BookingPayment obj = dbObj.BookingPayments.Find(id);
            dbObj.BookingPayments.Remove(obj);
            Save();
        }
        public void Save()
        {
            dbObj.SaveChanges();
        }
    }
    public class SecurityDepositRepository : ISecurityDepositRepository
    {
        private readonly HouseRentalManagementSystemContext dbObj;
        public SecurityDepositRepository(HouseRentalManagementSystemContext _dbObj)
        {
            dbObj = _dbObj;
        }

        public IEnumerable<SecurityDepositViewModel> GetAll()
        {
            IEnumerable<SecurityDepositViewModel> listOfDiposite = dbObj.SecurityDeposites.Select(e => new SecurityDepositViewModel
            {
                DepositPaymentId= e.DepositPaymentId,
                ReturnDate=e.ReturnDate,
                DepositAmount=e.DepositAmount,
                AptBookingId=e.AptBookingId,
            }).ToList();
            int indexNumber = 0;
            foreach (var item in listOfDiposite)
            {
                item.SirialNumber = indexNumber += 1;
            }
            return listOfDiposite;
        }
        public SecurityDepositViewModel GetSecurityDipositeByBookingId(int id)
        {
            SecurityDeposit e = dbObj.SecurityDeposites.AsNoTracking().SingleOrDefault(e => e.AptBookingId == id);
            if (e!=null)
            {
                SecurityDepositViewModel diposite = new SecurityDepositViewModel
                {
                    DepositPaymentId = e.DepositPaymentId,
                    ReturnDate = e.ReturnDate,
                    DepositAmount = e.DepositAmount,
                    AptBookingId = e.AptBookingId,
                };
                return diposite;

            }
            else
            {
                return null;
            }
        }
        public SecurityDepositViewModel GetById(int id)
        {
            SecurityDeposit e = dbObj.SecurityDeposites.AsNoTracking().SingleOrDefault(e => e.DepositPaymentId == id);
            SecurityDepositViewModel diposite = new SecurityDepositViewModel
            {
                DepositPaymentId = e.DepositPaymentId,
                ReturnDate = e.ReturnDate,
                DepositAmount = e.DepositAmount,
                AptBookingId = e.AptBookingId,
            };
            return diposite;
        }

        public void Insert(SecurityDepositViewModel e)
        {
            SecurityDeposit obj = new SecurityDeposit()
            {
                ReturnDate = e.ReturnDate,
                DepositAmount = e.DepositAmount,
                AptBookingId = e.AptBookingId,
            };
            dbObj.SecurityDeposites.Add(obj);
            Save();
        }

        public void Update(SecurityDepositViewModel e)
        {
            SecurityDeposit obj = new SecurityDeposit()
            {
                DepositPaymentId = e.DepositPaymentId,
                ReturnDate = e.ReturnDate,
                DepositAmount = e.DepositAmount,
                AptBookingId = e.AptBookingId,
            };
            dbObj.Entry(obj).State = EntityState.Modified;
            Save();
        }
        public void Delete(int id)
        {
            SecurityDeposit obj = dbObj.SecurityDeposites.Find(id);
            dbObj.SecurityDeposites.Remove(obj);
            Save();
        }
        public void Save()
        {
            dbObj.SaveChanges();
        }

    }
}

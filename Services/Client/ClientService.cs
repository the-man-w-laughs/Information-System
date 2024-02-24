using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Services.Client.Models;
using Services.Common.Model;
using ORMLibrary;

namespace Services.Client
{
    public class ClientService : BaseService, IClientService
    {
        public ClientService() : base()
        {
            if (!Context.Disabilities.Any())
            {
                InitStatuses();
            }
        }

        public ClientModel Add(ClientModel client)
        {
            try
            {
                if (Context.Clients.Any(e => e.IdentificationNumber == client.IdentificationNumber))
                    throw new ValidationException("Пользователь с таким идентификационным номером уже существует!");
                if (Context.Clients.Any(
                        e => e.PassportNumber == client.PassportNumber && e.PassportSeries == client.PassportSeries))
                    throw new ValidationException("Пользователь с такими серией и номером паспорта уже существует!");
                var dbClient = Mapper.Map<ClientModel, ORMLibrary.Client>(client);
                dbClient.Disability = Context.Disabilities.First(e => e.Id == client.Disability.Id);
                dbClient.Place = Context.Places.First(e => e.Id == client.Place.Id);
                dbClient.MartialStatus = Context.MartialStatus.First(e => e.Id == client.MartialStatus.Id);
                dbClient.Citizenship = Context.Citizenships.First(e => e.Id == client.Citizenship.Id);
                dbClient = Context.Clients.Add(dbClient);
                Context.SaveChanges();
                return Mapper.Map<ORMLibrary.Client, ClientModel>(dbClient);
            }
            catch (Exception ex)
            {
                throw new ServiceException($"Ошибка во время добавления нового клиента! {ex.Message}", ex);
            }
        }

        public IEnumerable<ClientModel> GetAll()
        {
            return Context.Clients.ToArray().Select(Mapper.Map<ORMLibrary.Client, ClientModel>);
        }

        public ClientModel Get(int id)
        {
            var client = Context.Clients.FirstOrDefault(e => e.Id == id);
            return Mapper.Map<ORMLibrary.Client, ClientModel>(client);
        }

        public void Delete(int id)
        {
            try
            {
                var client = Context.Clients.FirstOrDefault(e => e.Id == id);
                if (client != null)
                {
                    Context.Clients.Remove(client);
                    Context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new ServiceException("Ошибка во время удаления клиента!", ex);
            }
        }

        public void Update(ClientModel client)
        {
            try
            {
                var dbClient = Context.Clients.Where(e => e.Id == client.Id).FirstOrDefault();

                if (dbClient is null)
                {
                    throw new ServiceException("Пользователь не найден!");
                }

                if (Context.Clients.Any(e => e.Id != client.Id && e.IdentificationNumber == client.IdentificationNumber))
                    throw new ValidationException("Пользователь с таким идентификационным номером уже существует!");
                if (Context.Clients.Any(
                        e => e.Id != client.Id && e.PassportNumber == client.PassportNumber && e.PassportSeries == client.PassportSeries))
                    throw new ValidationException("Пользователь с такими серией и номером паспорта уже существует!");

                Mapper.Map(client, dbClient);

                dbClient.Disability = Context.Disabilities.First(e => e.Id == client.Disability.Id);
                dbClient.Place = Context.Places.First(e => e.Id == client.Place.Id);
                dbClient.MartialStatus = Context.MartialStatus.First(e => e.Id == client.MartialStatus.Id);
                dbClient.Citizenship = Context.Citizenships.First(e => e.Id == client.Citizenship.Id);

                Context.Entry(dbClient).State = EntityState.Modified;
                Context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new ServiceException($"Ошибка во время изменения данных клиента! {ex.Message}", ex);
            }
        }

        public IEnumerable<DisabilityModel> GetDisabilities()
        {
            return Context.Disabilities.ToArray().Select(Mapper.Map<Disability, DisabilityModel>);
        }

        public IEnumerable<MaritalStatusModel> GetMaritalStatuses()
        {
            return Context.MartialStatus.ToArray().Select(Mapper.Map<MartialStatus, MaritalStatusModel>);
        }

        public IEnumerable<PlaceModel> GetPlaces()
        {
            return Context.Places.ToArray().Select(Mapper.Map<Place, PlaceModel>);
        }

        public IEnumerable<CitizenshipModel> GetCitizenships()
        {
            return Context.Citizenships.ToArray().Select(Mapper.Map<Citizenship, CitizenshipModel>);
        }

        private void InitStatuses()
        {
            Context.Disabilities.AddRange(new[]
            {
                new Disability() {Status = "Без инвалидности"},
                new Disability() {Status = "Инвалидность 1 группы"},
                new Disability() {Status = "Инвалидность 2 группы"},
                new Disability() {Status = "Инвалидность 3 группы"}
            });

            Context.MartialStatus.AddRange(new[]
            {
                new MartialStatus() {Status = "Женат/замужем"},
                new MartialStatus() {Status = "Холост"}
            });

            Context.Places.AddRange(new[]
            {
                new Place() {Name = "Барановичи", Country = "Беларусь"},
                new Place() {Name = "Брест", Country = "Беларусь"},
                new Place() {Name = "Витебск", Country = "Беларусь"},
                new Place() {Name = "Гомель", Country = "Беларусь"},
                new Place() {Name = "Гродно", Country = "Беларусь"},
                new Place() {Name = "Минск", Country = "Беларусь"},
                new Place() {Name = "Могилёв", Country = "Беларусь"},
                new Place() {Name = "Полоцк", Country = "Беларусь"},
                new Place() {Name = "Поставы", Country = "Беларусь"},
                new Place() {Name = "Москва", Country = "Россия"},
                new Place() {Name = "Санкт-Петербург", Country = "Россия"},
                new Place() {Name = "Саратов", Country = "Россия"},
                new Place() {Name = "Нью-Йорк", Country = "США"},
                new Place() {Name = "Лондон", Country = "Великобритания"},
                new Place() {Name = "Берлин", Country = "Германия"},
            });

            Context.Citizenships.AddRange(new[]
            {
                new Citizenship() {Country = "Беларусь"},
                new Citizenship() {Country = "Россия"},
                new Citizenship() {Country = "США"},
                new Citizenship() {Country = "Великобритания"},
                new Citizenship() {Country = "Германия"}
            });

            Context.SaveChanges();
        }
    }
}

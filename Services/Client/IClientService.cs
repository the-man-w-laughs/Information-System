using System.Collections.Generic;
using Services.Client.Models;

namespace Services.Client
{
    public interface IClientService
    {
        ClientModel Add(ClientModel client);
        IEnumerable<ClientModel> GetAll();
        ClientModel Get(int id);
        void Delete(int id);
        void Update(ClientModel client);

        IEnumerable<DisabilityModel> GetDisabilities();
        IEnumerable<MaritalStatusModel> GetMaritalStatuses();
        IEnumerable<PlaceModel> GetPlaces();
        IEnumerable<CitizenshipModel> GetCitizenships();
    }
}

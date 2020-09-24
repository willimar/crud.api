using city.core.entities;
using city.test;
using crud.api.core.repositories;
using crud.api.register.entities.registers;
using crud.api.register.entities.registers.relational;
using crud.api.register.repositories.registers;
using data.provider.core.mongo;
using graph.simplify.consumer;
using graph.simplify.consumer.enums;
using OfficeOpenXml.FormulaParsing.Excel.Functions.Math;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace crud.api.test.repositories
{
    public class PersonIntegrationRepositoryTest
    {
        [Fact]
        public void InsertPerson()
        {
            Parallel.For(0, 5000, new ParallelOptions() { MaxDegreeOfParallelism = 10 }, i => {
                var provider = new DataProvider(new MongoClientFactory(), "crud-api");
                var repository = new PersonRepository(provider);
                var person = new Person()
                {
                    Gender = new Random(3).Next(),
                    Id = Guid.NewGuid(),
                    LastChangeDate = DateTime.UtcNow,
                    MaritalStatus = new Random(3).Next(),
                    Name = Faker.Name.FullName(Faker.NameFormats.Standard),
                    NickName = Faker.Name.First(),
                    PictureUrl = Faker.Internet.Url(),
                    Profession = Faker.Company.BS(),
                    Status = core.fieldType.RecordStatus.Active,
                    SpecialNeeds = false,
                    RegisterDate = DateTime.UtcNow,
                    Birthday = Faker.Identification.DateOfBirth(),
                    Addresses = GetAddresses(Faker.RandomNumber.Next(10)),
                    BirthCity = GetBirthCity(provider),
                    Contacts = GetContacts(Faker.RandomNumber.Next(10)),
                    Documents = GenerateDocuments(Faker.RandomNumber.Next(10))
                };
                repository.AppenData(person);
            });
        }

        private IEnumerable<PersonDocument> GenerateDocuments(int enumerable)
        {
            var result = new List<PersonDocument>();

            Parallel.For(0, enumerable, i => {
                var doc = new PersonDocument() { 
                    Id = Guid.NewGuid(),
                    LastChangeDate = DateTime.Now,
                    RegisterDate = DateTime.Now,
                    Status = core.fieldType.RecordStatus.Active,
                    Type = Faker.RandomNumber.Next(6).ToString(),
                };

                if (doc.Type.ToString() == "0")
                {
                    doc.Value = Faker.Identification.MedicareBeneficiaryIdentifier();
                }
                else if (doc.Type.ToString() == "1")
                {
                    doc.Value = Faker.Identification.SocialSecurityNumber();
                }
                else if (doc.Type.ToString() == "2")
                {
                    doc.Value = Faker.Identification.UkNationalInsuranceNumber();
                }
                else if (doc.Type.ToString() == "3")
                {
                    doc.Value = Faker.Identification.UkPassportNumber();
                }
                else
                {
                    doc.Value = Faker.Identification.UsPassportNumber();
                }

                result.Add(doc);
            });

            return result;
        }

        private IEnumerable<PersonContact> GetContacts(int enumerable)
        {
            var result = new List<PersonContact>();

            Parallel.For(0, enumerable, i => {
                var personContact = new PersonContact()
                {
                    Id = Guid.NewGuid(),
                    LastChangeDate = DateTime.Now,
                    RegisterDate = DateTime.Now,
                    Status = core.fieldType.RecordStatus.Active,
                    Type = Faker.RandomNumber.Next(8),
                    Value = Faker.Lorem.Words(1).FirstOrDefault(),
                };

                result.Add(personContact);
            });

            return result;
        }

        private City GetBirthCity(DataProvider dataProvider)
        {
            var cityRep = new BaseRepository<City>(dataProvider);
            var city = cityRep.GetData(x => true, 1, Faker.RandomNumber.Next(5500)).FirstOrDefault();

            return city;
        }

        private dynamic PostalCode()
        {
            var postalCodeCheck = new GraphClient();
            var body = postalCodeCheck.AppendBody("Address");

            body.QueryInfo.Limit = 1;
            body.QueryInfo.Page = Faker.RandomNumber.Next(809999);

            body.ResultFields.Add("postalCode");
            body.ResultFields.Add("district");
            body.ResultFields.Add("fullStreetName");
            body.ResultFields.Add("city{name, state{name}}");

            postalCodeCheck.Resolve(new Uri(@"https://postalcode-api.herokuapp.com/graphql"));

            return postalCodeCheck.Result.data.address[0];
        }

        private IEnumerable<PersonAddress> GetAddresses(int value)
        {
            var result = new List<PersonAddress>();

            Parallel.For(0, value, new ParallelOptions() { MaxDegreeOfParallelism = 5 }, i => {
                //var city = GetBirthCity(dataProvider);
                dynamic postalCode = PostalCode();
                var city = Convert.ToString(postalCode.city.name);
                var state = Convert.ToString(postalCode.city.state.name);
                var neighborhood = Convert.ToString(postalCode.district);
                var cep = Convert.ToString(postalCode.postalCode);
                var fullStreetName = Convert.ToString(postalCode.fullStreetName);
                var complement = "";

                var count = Faker.RandomNumber.Next(4);
                complement = string.Join(" ", Faker.Lorem.Words(count == 0 ? 1 : count));

                var adderess = new PersonAddress()
                {
                    AddressType = Faker.RandomNumber.Next(6),
                    City = city,
                    Complement = complement,
                    Country = "Brasil",
                    State = state,
                    Id = Guid.NewGuid(),
                    LastChangeDate = DateTime.Now,
                    Neighborhood = neighborhood,
                    PostalCode = cep,
                    Number = Faker.RandomNumber.Next(5000).ToString(),
                    RegisterDate = DateTime.Now,
                    Status = core.fieldType.RecordStatus.Active,
                    StreetName = fullStreetName
                };

                result.Add(adderess);
            });

            return result;
        }
    }
}

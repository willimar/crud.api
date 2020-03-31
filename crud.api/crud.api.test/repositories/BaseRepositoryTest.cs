using crud.api.test.mock;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace crud.api.test.repositories
{
    public class BaseRepositoryTest
    {
        [Fact]
        public void AppenDataTest()
        {
            var provider = new ProviderMock();
            var repository = new RepositoryMock(provider);

            var result = repository.AppenData(new TesteEntity() { LastChangeDate = DateTime.UtcNow, RegisterDate = DateTime.UtcNow, Id = Guid.NewGuid() });

            Assert.Single(result.Where(i => i.MesageType == "AppendData"));
        }

        [Fact]
        public void AppenDataIvalidFieldsTest()
        {
            var provider = new ProviderMock();
            var repository = new RepositoryMock(provider);

            var result = repository.AppenData(new TesteEntity());

            Assert.Single(result.Where(i => i.MesageType == "IdInválido"));
            Assert.Single(result.Where(i => i.MesageType == "RegisterDateInvalid"));
            Assert.Single(result.Where(i => i.MesageType == "LastChangeDateInvalid"));
        }

        [Fact]
        public void DeleteDataTest()
        {
            var provider = new ProviderMock();
            var repository = new RepositoryMock(provider);
            var record = new TesteEntity() { LastChangeDate = DateTime.UtcNow, RegisterDate = DateTime.UtcNow, Id = Guid.NewGuid() };

            repository.AppenData(record);
            var result = repository.DeleteData(record);

            Assert.Single(result.Where(i => i.MesageType == "DeltedRecord"));
        }

        [Fact]
        public void DeleteDataRecordNotFoundTest()
        {
            var provider = new ProviderMock();
            var repository = new RepositoryMock(provider);

            var result = repository.DeleteData(new TesteEntity());

            Assert.Single(result.Where(i => i.MesageType == "RecordNotFoundException"));
        }

        [Fact]
        public void GetDataTest()
        {
            var provider = new ProviderMock();
            var repository = new RepositoryMock(provider);
            var record = new TesteEntity() { LastChangeDate = DateTime.UtcNow, RegisterDate = DateTime.UtcNow, Id = Guid.NewGuid() };

            repository.AppenData(record);

            var result = repository.GetData(e => e.Id == record.Id);
            Assert.Single(result);
        }

        [Fact]
        public void UpdateDataTest()
        {
            var provider = new ProviderMock();
            var repository = new RepositoryMock(provider);
            var record = new TesteEntity() { LastChangeDate = DateTime.UtcNow, RegisterDate = DateTime.UtcNow, Id = Guid.NewGuid() };

            repository.AppenData(record);

            var result = repository.UpdateData(record, e => e.Id == record.Id);
            Assert.Single(result.Where(i => i.MesageType == "RecordChanged"));
        }

        [Fact]
        public void UpdateDataRecordNotFoundTest()
        {
            var provider = new ProviderMock();
            var repository = new RepositoryMock(provider);
            var record = new TesteEntity() { LastChangeDate = DateTime.UtcNow, RegisterDate = DateTime.UtcNow, Id = Guid.NewGuid() };

            var result = repository.UpdateData(record, e => e.Id == record.Id);
            Assert.Single(result.Where(i => i.MesageType == "RecordNotFoundException"));
        }

        [Fact]
        public void UpdateDataInvalidFieldsTest()
        {
            var provider = new ProviderMock();
            var repository = new RepositoryMock(provider);
            var record = new TesteEntity();

            var result = repository.UpdateData(new TesteEntity(), e => e.Id == record.Id);
            Assert.Single(result.Where(i => i.MesageType == "IdInválido"));
            Assert.Single(result.Where(i => i.MesageType == "RegisterDateInvalid"));
            Assert.Single(result.Where(i => i.MesageType == "LastChangeDateInvalid"));
        }
    }
}

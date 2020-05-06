using crud.api.core.exceptions;
using crud.api.core.fieldType;
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

            var result = repository.AppenData(new TesteEntity() { LastChangeDate = DateTime.UtcNow, RegisterDate = DateTime.UtcNow, Id = Guid.NewGuid(), Status = RecordStatus.Active });

            Assert.Single(result.Where(i => i.MessageType == "AppendData"));
        }

        [Fact]
        public void AppenDataIvalidFieldsTest()
        {
            var provider = new ProviderMock();
            var repository = new RepositoryMock(provider);

            var result = repository.AppenData(new TesteEntity());

            Assert.True(result.Count(c => c.MessageType.Equals(nameof(FieldValueException))) == 4);
        }

        [Fact]
        public void DeleteDataTest()
        {
            var provider = new ProviderMock();
            var repository = new RepositoryMock(provider);
            var record = new TesteEntity() { LastChangeDate = DateTime.UtcNow, RegisterDate = DateTime.UtcNow, Id = Guid.NewGuid(), Status = RecordStatus.Active };

            repository.AppenData(record);
            var result = repository.DeleteData(record);

            Assert.Single(result.Where(i => i.MessageType == "DeltedRecord"));
        }

        [Fact]
        public void DeleteDataRecordNotFoundTest()
        {
            var provider = new ProviderMock();
            var repository = new RepositoryMock(provider);

            var result = repository.DeleteData(new TesteEntity());

            Assert.Single(result.Where(i => i.MessageType == "RecordNotFoundException"));
        }

        [Fact]
        public void GetDataTest()
        {
            var provider = new ProviderMock();
            var repository = new RepositoryMock(provider);
            var record = new TesteEntity() { LastChangeDate = DateTime.UtcNow, RegisterDate = DateTime.UtcNow, Id = Guid.NewGuid(), Status = RecordStatus.Active };

            repository.AppenData(record);

            var result = repository.GetData(e => e.Id == record.Id);
            Assert.Single(result);
        }

        [Fact]
        public void UpdateDataTest()
        {
            var provider = new ProviderMock();
            var repository = new RepositoryMock(provider);
            var record = new TesteEntity() { LastChangeDate = DateTime.UtcNow, RegisterDate = DateTime.UtcNow, Id = Guid.NewGuid(), Status = RecordStatus.Active };

            repository.AppenData(record);

            var result = repository.UpdateData(record, e => e.Id == record.Id);
            Assert.Single(result.Where(i => i.MessageType == "RecordChanged"));
        }

        [Fact]
        public void UpdateDataRecordNotFoundTest()
        {
            var provider = new ProviderMock();
            var repository = new RepositoryMock(provider);
            var record = new TesteEntity() { LastChangeDate = DateTime.UtcNow, RegisterDate = DateTime.UtcNow, Id = Guid.NewGuid(), Status = RecordStatus.Active };

            var result = repository.UpdateData(record, e => e.Id == record.Id);
            Assert.Single(result.Where(i => i.MessageType == "RecordNotFoundException"));
        }

        [Fact]
        public void UpdateDataInvalidFieldsTest()
        {
            var provider = new ProviderMock();
            var repository = new RepositoryMock(provider);
            var record = new TesteEntity();

            var result = repository.UpdateData(new TesteEntity(), e => e.Id == record.Id);

            Assert.True(result.Count(c => c.MessageType.Equals(nameof(FieldValueException))) == 4);
        }
    }
}

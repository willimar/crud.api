using crud.api.core.attributes;
using crud.api.core.entities;
using System;
using System.Collections;
using System.Collections.Generic;

namespace crud.api.register.entities.registers
{
    public class Product : BaseEntity
    {
        [IsRequiredField]
        public string Name { get; set; }
        public string InternalName { get; set; }
        public string PopularName { get; set; }
        public string InternalCode { get; set; }
        public string OfficialCode { get; set; }
        public string MeasureUnit { get; set; }
        public decimal MinimumStock { get; set; }
        public decimal MaximumStock { get; set; }
        public string Corridor { get; set; }
        public string Bookcase { get; set; }
        public string Shelf { get; set; }
        public decimal CostValue { get; set; }
        public decimal SellValue { get; set; }
        public bool Fragile { get; set; }
        public bool Packing { get; set; }
        public decimal QuantityPacking { get; set; }
        public decimal GrossWeight { get; set; }
        public decimal NetWeight { get; set; }
        public IEnumerable<DictionaryField> ProductGroups { get; set; }
        public IEnumerable<DictionaryMesage> ProductLog { get; set; }
        public IEnumerable<Person> Providers { get; set; }

        public override bool Equals(object obj)
        {
            var unboxed = obj as Product;

            if (this.BaseEquals(unboxed))
            {
                return true;
            }

            if (Convert.ToBoolean(unboxed.Name?.Equals(this.Name)))
            {
                return true;
            }

            if (!string.IsNullOrWhiteSpace(this.InternalCode) && Convert.ToBoolean(unboxed.InternalCode?.Equals(this.InternalCode)))
            {
                return true;
            }

            if (!string.IsNullOrWhiteSpace(this.OfficialCode) && Convert.ToBoolean(unboxed.OfficialCode?.Equals(this.OfficialCode)))
            {
                return true;
            }

            return false;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}

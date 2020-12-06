using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace SistemaDeAgendamentoDeViagens.Models.DataAnnotation
{
    public class CompararDatas : ValidationAttribute, IClientModelValidator
    {
        public string CompareData { get; set; }
        public CompararDatas(string compararData)
        {
            CompareData = compararData;
        }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (validationContext.ObjectInstance != null)
            {
                Type _t = validationContext.ObjectInstance.GetType();
                PropertyInfo _d = _t.GetProperty(CompareData);
                if (_d != null)
                {
                    DateTime _dt1 = (DateTime)value;
                    DateTime _dt0 = (DateTime)_d.GetValue(validationContext.ObjectInstance, null);
                    if (_dt1 != null && _dt0 != null && _dt0 <= _dt1)
                    {
                        return ValidationResult.Success;
                    }
                }
            }
            return new ValidationResult("A data de chegada deve acontecer depois da data de Partida");
        }
        public void AddValidation(ClientModelValidationContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }
            context.Attributes.Add("Comparar-Datas", ErrorMessageString);
            context.Attributes.Add("Compara_Datas:param", CompareData);
        }
    }
}

using System;
using System.Collections.Generic;

namespace PortfolioEngineCore.Infrastructure.Fields
{
    public class FieldFactory
    {
        #region Fields (1) 

        private readonly Dictionary<int, Type> _fieldDictionary;

        #endregion Fields 

        #region Constructors (1) 

        /// <summary>
        /// Initializes a new instance of the <see cref="FieldFactory"/> class.
        /// </summary>
        public FieldFactory()
        {
            _fieldDictionary = new Dictionary<int, Type>
                                   {
                                       {(int) PFEFieldType.DateField, typeof (DateField)},
                                       {(int) PFEFieldType.NumberField, typeof (NumberField)},
                                       {(int) PFEFieldType.CodeField, typeof (CodeField)},
                                       {(int) PFEFieldType.CostField, typeof (CostField)},
                                       {(int) PFEFieldType.TextField, typeof (TextField)},
                                       {(int) PFEFieldType.FlagField, typeof (FlagField)},
                                       {(int) PFEFieldType.MultiValueCodeField, typeof (MultiValueCodeField)}
                                   };
        }

        #endregion Constructors 

        #region Methods (1) 

        // Public Methods (1) 

        /// <summary>
        /// Makes the specified field.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <param name="name">The name.</param>
        /// <param name="fieldType">Type of the field.</param>
        /// <returns></returns>
        public IField Make(int id, string name, int fieldType)
        {
            if (!_fieldDictionary.ContainsKey(fieldType))
            {
                throw new PFEException((int) PFEError.FieldTypeNotFound,
                                       string.Format("{0} is not a valid PFE field type.", fieldType));
            }

            return (IField) Activator.CreateInstance(_fieldDictionary[fieldType], new object[] {id, name});
        }

        #endregion Methods 
    }
}
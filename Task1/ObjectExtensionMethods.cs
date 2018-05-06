using System.Reflection;

namespace Task1
{
    public static class ObjectExtensionMethods
    {
        /// <summary>
        /// Copies properties from target object if property names are similar
        /// or if target property has similar MatchTargetAttribute 
        /// </summary>
        /// <param name="self">An object</param>
        /// <param name="target">An object</param>
        public static void MatchPropertiesFrom(this object self, object target)
        {
            var selfProperties = self.GetType().GetProperties();
            foreach (var selfProperty in selfProperties)
            {
                object targetPropertyValue = null;
                var targetProperties = target.GetType().GetProperties();
                foreach (var targetProperty in targetProperties)
                {
                    var matchTargetAttribute = (MatchTargetAttribute)targetProperty.GetCustomAttribute(typeof(MatchTargetAttribute));
                    if (selfProperty.PropertyType == targetProperty.PropertyType
                        && ((matchTargetAttribute != null && selfProperty.Name == matchTargetAttribute.TargetPropertyName)
                            || selfProperty.Name == targetProperty.Name))
                    {
                        targetPropertyValue = targetProperty.GetValue(target);
                    }
                }
                selfProperty.SetValue(self, targetPropertyValue);
            }
        }
    }
}
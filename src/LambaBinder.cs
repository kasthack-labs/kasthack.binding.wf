using System;
using System.Linq.Expressions;
using System.Windows.Forms;

namespace  kasthack.binding.wf {
    public static class LambaBinder
    {
        /// <summary>
        /// Bind Control property to object property. Usage: control.Bind(a=>a.Property, () => bindObject.BindProperty)
        /// </summary>
        /// <typeparam name="TControl">Control type. Don't specify it yourself. It should be determined by compiler.</typeparam>
        /// <typeparam name="TProperty">Control property type. Don't specify it yourself. It should be determined by compiler.</typeparam>
        /// <typeparam name="TBind">Bind property type. Don't specify it yourself. It should be determined by compiler.</typeparam>
        /// <param name="control">Control</param>
        /// <param name="property">Control property</param>
        /// <param name="bind">Bind expression. () => binbObject.Property</param>
        /// <param name="formattingEnabled">enable value formatting</param>
        /// <param name="updateMode">Bindproperty update mode</param>
        public static void Bind<TControl, TProperty, TBind>(this TControl control, Expression<Func<TControl, TProperty>> property, Expression<Func<TBind>> bind, bool formattingEnabled = false, DataSourceUpdateMode updateMode = DataSourceUpdateMode.OnPropertyChanged) where TControl : IBindableComponent => BindInternal(control, property, bind, formattingEnabled, updateMode);

        private static void BindInternal<TControl>(TControl control, LambdaExpression property, LambdaExpression bind, bool formattingEnabled, DataSourceUpdateMode updateMode) where TControl : IBindableComponent
        {
            //validate
            if (property == null || property.NodeType != ExpressionType.Lambda || property.Body.NodeType != ExpressionType.MemberAccess)
                throw new ArgumentException("Control expression must be a property lambda", nameof(property));
            if (bind == null || bind.NodeType != ExpressionType.Lambda || bind.Body.NodeType != ExpressionType.MemberAccess)
                throw new ArgumentException("Source expression must be a property lambda", nameof(bind));
            var body = (bind.Body as MemberExpression);

            control.DataBindings.Add(
                                     //control property name
                                     (property.Body as MemberExpression).Member.Name,
                                     // compile parent expression and get object
                                     // will return $obj for a=>$obj.property and ()=>$obj.property
                                     Expression.Lambda<Func<object>>(body.Expression).Compile()(),
                                     //source property name
                                     body.Member.Name,
                                     formattingEnabled,
                                     updateMode
                );
        }
    }
}

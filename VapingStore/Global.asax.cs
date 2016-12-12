using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using VapingStore.Entities;
using VapingStore.Infrastructure;

namespace VapingStore
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            ModelBinders.Binders.Add(typeof(Cart), new CartModelBinder());
        }

        protected void Application_Error(Object sender, EventArgs e)
        {
            try
            {
                //ловим последнее возникшее исключение
                Exception lastError = Server.GetLastError();

                if (lastError != null)
                {
                    //Записываем непосредственно исключение, вызвавшее данное, в
                    //Session для дальнейшего использования
                    Session["ErrorException"] = lastError.InnerException;
                }

                // Обнуление ошибки на сервере
                Server.ClearError();

                // Перенаправление на свою страницу отображения ошибки
                Response.Redirect("~/Error.html");
            }
            catch (Exception)
            {
                // если мы всёже приходим сюда - значит обработка исключения 
                // сама сгенерировала исключение, мы ничего не делаем, чтобы
                // не создать бесконечный цикл
                Response.Write("К сожалению произошла критическая ошибка. Нажмите кнопку 'Назад' в браузере и попробуйте ещё раз. ");
            }
        }
    }
}

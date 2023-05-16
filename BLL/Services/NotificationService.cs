using BLL.DTOs;
using DAL.Models;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class NotificationService
    {
        public static List<NotificationDTO> Get()
        {
            var data = DataAccessFactory.NotificationData().Get();
            return data.Select(Convert).ToList();
        }

        public static NotificationDTO Get(int id)
        {
            return Convert(DataAccessFactory.NotificationData().Get(id));
        }

        public static bool Create(NotificationDTO notification)
        {
            var data = Convert(notification);
            var res = DataAccessFactory.NotificationData().Insert(data);

            return res = true;
        }

        public static bool Delete(int id)
        {
            return DataAccessFactory.NotificationData().Delete(id);
        }

        public static bool Update(int id, NotificationDTO notification)
        {
            var extNotification = DataAccessFactory.NotificationData().Get(id);
            if (extNotification == null) return false;

            extNotification.Message = notification.Message;
            extNotification.UserId = notification.UserId;

            var res = DataAccessFactory.NotificationData().Update(extNotification);

            return res = true;
        }

        private static NotificationDTO Convert(Notification notification)
        {
            return new NotificationDTO
            {
                Id = notification.Id,
                Message = notification.Message,
                UserId = notification.UserId
            };
        }

        private static Notification Convert(NotificationDTO notification)
        {
            return new Notification
            {
                Id = notification.Id,
                Message = notification.Message,
                UserId = notification.UserId
            };
        }
    }

}
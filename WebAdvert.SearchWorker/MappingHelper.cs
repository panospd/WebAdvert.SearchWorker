﻿using System;
using System.Collections.Generic;
using System.Text;
using AdvertApi.Models.Messages;

namespace WebAdvert.SearchWorker
{
    public static class MappingHelper
    {
        public static AdvertType Map(AdvertConfirmedMessage message)
        {
            return new AdvertType
            {
                Id = message.Id,
                Title = message.Title,
                CreationDateTime = DateTime.UtcNow
            };
        }
    }
}

using HouseBroker.Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseBroker.Infastructure.Data.DataDbContext
{
    public class SeedDataDbContext : DbContext
    {
        public SeedDataDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Property> Properties { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Property>().HasData(
                 new Property
                 {
                     PropertyId = Guid.NewGuid(),
                     PropertyName = "Bag Durbar",
                     State = "Bagmati",
                     District = "Kathmandu",
                     Municipality = "Kathmandu",
                     WardNo = 2,
                     PhotoURL = "https://fastly.picsum.photos/id/49/1280/792.jpg?hmac=NnUJy0O9-pXHLmY2loqVs2pJmgw9xzuixgYOk4ALCXU",
                     Location = "Nakkhu",
                     PropertyDescription = "\r\nBag Durbar, located in the bustling heart of Kathmandu, Nepal, is a historical and cultural landmark. This regal palace, with its distinctive architecture and rich heritage, stands as a witness to the city's evolution over the years. Bag Durbar has played a significant role in the political and social fabric of the region, reflecting the grandeur of its past. The site, adorned with traditional designs and surrounded by the vibrant energy of Kathmandu, invites visitors to explore its halls, courtyards, and gardens, offering a glimpse into the cultural tapestry of Nepal.",
                     PropertyType = "Mansion",
                     AskingPrice = "300K",
                     DateCreated = DateTime.Now,
                     BrokerContact = 9876543210
                 },
                 new Property
                 {
                     PropertyId = Guid.NewGuid(),
                     PropertyName = "Rani Mahal",
                     State = "Gandaki",
                     District = "Palpa",
                     Municipality = "Mardi",
                     WardNo = 5,
                     PhotoURL = "https://fastly.picsum.photos/id/57/2448/3264.jpg?hmac=ewraXYesC6HuSEAJsg3Q80bXd1GyJTxekI05Xt9YjfQ",
                     Location = "Rani Chowk",
                     PropertyDescription = "Rani Mahal, a historic palace nestled in the heart of Nepal, exudes grandeur and mystery. Its elegant architecture, adorned with intricate carvings and vibrant hues, whispers tales of royalty and romance. Standing tall amidst lush greenery, it is a testament to a bygone era, where every corner holds secrets waiting to be discovered. With its majestic presence and timeless beauty, Rani Mahal continues to enchant and captivate visitors, inviting them to delve into its rich history and immerse themselves in its allure.",
                     PropertyType = "Mansion",
                     AskingPrice = "300K",
                     DateCreated = DateTime.Now,
                     BrokerContact = 98765123456
                 },
                 new Property
                 {
                     PropertyId = Guid.NewGuid(),
                     PropertyName = "Batla House",
                     State = "Koshi",
                     District = "Jhapa",
                     Municipality = "Illam",
                     WardNo = 5,
                     PhotoURL = "https://fastly.picsum.photos/id/58/1280/853.jpg?hmac=YO3QnOm9TpyM5DqsJjoM4CHg8oIq4cMWLpd9ALoP908",
                     Location = "KP Oli Chowk",
                     PropertyDescription = "Bag Durbar, located in the bustling heart of Kathmandu, Nepal, is a historical and cultural landmark. This regal palace, with its distinctive architecture and rich heritage, stands as a witness to the city's evolution over the years. Bag Durbar has played a significant role in the political and social fabric of the region, reflecting the grandeur of its past. The site, adorned with traditional designs and surrounded by the vibrant energy of Kathmandu, invites visitors to explore its halls, courtyards, and gardens, offering a glimpse into the cultural tapestry of Nepal.",
                     PropertyType = "Mansion",
                     AskingPrice = "3008K",
                     DateCreated = DateTime.Now,
                     BrokerContact = 9876573210
                 },
                 new Property
                 {
                     PropertyId = Guid.NewGuid(),
                     PropertyName = "Basnet Residency",
                     State = "Karnali",
                     District = "Surkhet",
                     Municipality = "Surkhet",
                     WardNo = 4,
                     PhotoURL = "https://fastly.picsum.photos/id/76/4912/3264.jpg?hmac=VkFcSa2Rbv0R0ndYnz_FAmw02ON1pPVjuF_iVKbiiV8",
                     Location = "Basnet Tol",
                     PropertyDescription = "Bag Durbar, located in the bustling heart of Kathmandu, Nepal, is a historical and cultural landmark. This regal palace, with its distinctive architecture and rich heritage, stands as a witness to the city's evolution over the years. Bag Durbar has played a significant role in the political and social fabric of the region, reflecting the grandeur of its past. The site, adorned with traditional designs and surrounded by the vibrant energy of Kathmandu, invites visitors to explore its halls, courtyards, and gardens, offering a glimpse into the cultural tapestry of Nepal.",
                     PropertyType = "Private House",
                     AskingPrice = "3070K",
                     DateCreated = DateTime.Now,
                     BrokerContact = 9876543880
                 },
                 new Property
                 {
                     PropertyId = Guid.NewGuid(),
                     PropertyName = "Sharma Niwas",
                     State = "Koshi",
                     District = "Therathum",
                     Municipality = "Kavre",
                     WardNo = 6,
                     PhotoURL = "https://fastly.picsum.photos/id/78/1584/2376.jpg?hmac=80UVSwpa9Nfcq7sQ5kxb9Z5sD2oLsbd5zkFO5ybMC4E",
                     Location = "Kavre Chowk",
                     PropertyDescription = "Rani Mahal, a historic palace nestled in the heart of Nepal, exudes grandeur and mystery. Its elegant architecture, adorned with intricate carvings and vibrant hues, whispers tales of royalty and romance. Standing tall amidst lush greenery, it is a testament to a bygone era, where every corner holds secrets waiting to be discovered. With its majestic presence and timeless beauty, Rani Mahal continues to enchant and captivate visitors, inviting them to delve into its rich history and immerse themselves in its allure.",
                     PropertyType = "Apartment Building",
                     AskingPrice = "300K",
                     DateCreated = DateTime.Now,
                     BrokerContact = 9876543999
                 },
                 new Property
                 {
                     PropertyId = Guid.NewGuid(),
                     PropertyName = "Kantipur Complex",
                     State = "Bagmati",
                     District = "Kathmandu",
                     Municipality = "Kathmandu",
                     WardNo = 8,
                     PhotoURL = "https://fastly.picsum.photos/id/101/2621/1747.jpg?hmac=cu15YGotS0gIYdBbR1he5NtBLZAAY6aIY5AbORRAngs",
                     Location = "Thapathali",
                     PropertyDescription = "Bag Durbar, located in the bustling heart of Kathmandu, Nepal, is a historical and cultural landmark. This regal palace, with its distinctive architecture and rich heritage, stands as a witness to the city's evolution over the years. Bag Durbar has played a significant role in the political and social fabric of the region, reflecting the grandeur of its past. The site, adorned with traditional designs and surrounded by the vibrant energy of Kathmandu, invites visitors to explore its halls, courtyards, and gardens, offering a glimpse into the cultural tapestry of Nepal.",
                     PropertyType = "Business Complex",
                     AskingPrice = "3000K",
                     DateCreated = DateTime.Now,
                     BrokerContact = 9876577777
                 },
                 new Property
                 {
                     PropertyId = Guid.NewGuid(),
                     PropertyName = "Bag Durbar",
                     State = "Bagmati",
                     District = "Kathmandu",
                     Municipality = "Kathmandu",
                     WardNo = 2,
                     PhotoURL = "https://fastly.picsum.photos/id/49/1280/792.jpg?hmac=NnUJy0O9-pXHLmY2loqVs2pJmgw9xzuixgYOk4ALCXU",
                     Location = "Nakkhu",
                     PropertyDescription = "\r\nBag Durbar, located in the bustling heart of Kathmandu, Nepal, is a historical and cultural landmark. This regal palace, with its distinctive architecture and rich heritage, stands as a witness to the city's evolution over the years. Bag Durbar has played a significant role in the political and social fabric of the region, reflecting the grandeur of its past. The site, adorned with traditional designs and surrounded by the vibrant energy of Kathmandu, invites visitors to explore its halls, courtyards, and gardens, offering a glimpse into the cultural tapestry of Nepal.",
                     PropertyType = "Mansion",
                     AskingPrice = "300K",
                     DateCreated = DateTime.Now,
                     BrokerContact = 9876543210
                 },
                 new Property
                 {
                     PropertyId = Guid.NewGuid(),
                     PropertyName = "Rani Mahal",
                     State = "Gandaki",
                     District = "Palpa",
                     Municipality = "Mardi",
                     WardNo = 5,
                     PhotoURL = "https://fastly.picsum.photos/id/57/2448/3264.jpg?hmac=ewraXYesC6HuSEAJsg3Q80bXd1GyJTxekI05Xt9YjfQ",
                     Location = "Rani Chowk",
                     PropertyDescription = "Rani Mahal, a historic palace nestled in the heart of Nepal, exudes grandeur and mystery. Its elegant architecture, adorned with intricate carvings and vibrant hues, whispers tales of royalty and romance. Standing tall amidst lush greenery, it is a testament to a bygone era, where every corner holds secrets waiting to be discovered. With its majestic presence and timeless beauty, Rani Mahal continues to enchant and captivate visitors, inviting them to delve into its rich history and immerse themselves in its allure.",
                     PropertyType = "Mansion",
                     AskingPrice = "300K",
                     DateCreated = DateTime.Now,
                     BrokerContact = 98765123456
                 },
                 new Property
                 {
                     PropertyId = Guid.NewGuid(),
                     PropertyName = "Batla House",
                     State = "Koshi",
                     District = "Jhapa",
                     Municipality = "Illam",
                     WardNo = 5,
                     PhotoURL = "https://fastly.picsum.photos/id/58/1280/853.jpg?hmac=YO3QnOm9TpyM5DqsJjoM4CHg8oIq4cMWLpd9ALoP908",
                     Location = "KP Oli Chowk",
                     PropertyDescription = "Bag Durbar, located in the bustling heart of Kathmandu, Nepal, is a historical and cultural landmark. This regal palace, with its distinctive architecture and rich heritage, stands as a witness to the city's evolution over the years. Bag Durbar has played a significant role in the political and social fabric of the region, reflecting the grandeur of its past. The site, adorned with traditional designs and surrounded by the vibrant energy of Kathmandu, invites visitors to explore its halls, courtyards, and gardens, offering a glimpse into the cultural tapestry of Nepal.",
                     PropertyType = "Mansion",
                     AskingPrice = "3008K",
                     DateCreated = DateTime.Now,
                     BrokerContact = 9876573210
                 },
                 new Property
                 {
                     PropertyId = Guid.NewGuid(),
                     PropertyName = "Basnet Residency",
                     State = "Karnali",
                     District = "Surkhet",
                     Municipality = "Surkhet",
                     WardNo = 4,
                     PhotoURL = "https://fastly.picsum.photos/id/76/4912/3264.jpg?hmac=VkFcSa2Rbv0R0ndYnz_FAmw02ON1pPVjuF_iVKbiiV8",
                     Location = "Basnet Tol",
                     PropertyDescription = "Bag Durbar, located in the bustling heart of Kathmandu, Nepal, is a historical and cultural landmark. This regal palace, with its distinctive architecture and rich heritage, stands as a witness to the city's evolution over the years. Bag Durbar has played a significant role in the political and social fabric of the region, reflecting the grandeur of its past. The site, adorned with traditional designs and surrounded by the vibrant energy of Kathmandu, invites visitors to explore its halls, courtyards, and gardens, offering a glimpse into the cultural tapestry of Nepal.",
                     PropertyType = "Private House",
                     AskingPrice = "3070K",
                     DateCreated = DateTime.Now,
                     BrokerContact = 9876543880
                 }
            );
        }

    }
}

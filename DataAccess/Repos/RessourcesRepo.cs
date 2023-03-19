﻿using DataAccess.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using RRelationnelle.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace RRelationnelle.Repos
{
    public class RessourcesRepo : IRessourceRepo
    {
        private readonly RrelationnelApiContext _Dbcontext;
        private readonly CategoryRepository _categ;
        private readonly IUserRepo _user;

        public RessourcesRepo(RrelationnelApiContext ctx, CategoryRepository categ, IUserRepo user)
        {
            _Dbcontext = ctx;
            _categ = categ;
            _user = user;
        }

        public Task<ActionResult<bool>> Delete()
        {
            throw new NotImplementedException();
        }

        public async Task<Ressource> GetRessourceById(string id)
        {
            Ressource ressource = await _Dbcontext.Ressource.FindAsync(id);
            return ressource;
        }

        public async Task<List<Alternances>> GetFormation(JArray result)
        {
            //using var transaction = await _Dbcontext.Database.BeginTransactionAsync();

            List<Alternances> _Alternances = new List<Alternances>();

            foreach (JObject obj in result)
            {
                // je recupere les info dont j'ai besoins dans mon tableau de resultats renvoyé par l'api
                string id = (string)obj["id"];
                string name = (string)obj["longTitle"];
                string onisepUrl = (string)obj["onisepUrl"];
                string Diploma = (string)obj["diploma"];
                string period = (string)obj["onisepUrl"];
                string capacity = (string)obj["capacity"];
                string ville = (string)obj.SelectToken("place.city");
                string zipcode = (string)obj.SelectToken("place.zipCode");
                string emailcontact = (string)obj.SelectToken("contact.email");

                var categ = await _categ.Get(1);
                var user = await _user.Get(1);
                var ressource = new Ressource(id, name, categ, onisepUrl, user);


                _Dbcontext.Ressource.Add(ressource);
                int nb = _Dbcontext.SaveChanges();

                var alternance = new Alternances(id, name, categ, onisepUrl, user, Diploma, period, capacity, ville, zipcode, emailcontact);
                _Alternances.Add(alternance);
            }
            //await transaction.CommitAsync();

            return _Alternances;
        }

        public Task<Ressource> Create(Ressource obj)
        {
            throw new NotImplementedException();
        }

        public Task<Ressource> Update(Ressource obj, int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Archive(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Ressource> Get(int id)
        {
            Ressource ressource = await _Dbcontext.Ressource.FindAsync(id);
            return ressource;
        }
    }
}

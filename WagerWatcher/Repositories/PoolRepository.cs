﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate.Criterion;
using WagerWatcher.Controller;

namespace WagerWatcher.Repositories
{
    public class PoolRepository
    {
        public void Add(Pool raceBetType)
        {
            using (var session = NHibernateHelper.OpenSession())
            using (var transaction = session.BeginTransaction())
            {
                session.Save(raceBetType);
                transaction.Commit();
            }
        }

        public void Update(Pool raceBetType)
        {
            using (var session = NHibernateHelper.OpenSession())
            using (var transaction = session.BeginTransaction())
            {
                session.Update(raceBetType);
                transaction.Commit();
            }
        }

        public void Remove(Pool raceBetType)
        {
            using (var session = NHibernateHelper.OpenSession())
            using (var transaction = session.BeginTransaction())
            {
                session.Delete(raceBetType);
                transaction.Commit();
            }
        }

        public Pool GetByID(Guid id)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                return session.Get<Pool>(id);
            }
        }

        public static Pool GetByBetTypeAndRace(Guid betTypeID, Guid raceID)
        {
            // make sure when its populating the DB, that one isnt already there
            Pool pool;
            using (var session = NHibernateHelper.OpenSession())
            {
                pool = session
                    .CreateCriteria(typeof (Pool))
                    .Add(Restrictions.Eq("BetTypeId", betTypeID))
                    .Add(Restrictions.Eq("RaceId", raceID))
                    .UniqueResult<Pool>();
            }
            return pool;
        }
    }
}
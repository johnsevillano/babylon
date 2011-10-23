/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */

package Babylon.Services.Repositories;

import java.util.List;
import java.util.ArrayList;
import java.util.Iterator;

import org.hibernate.Session;
import org.hibernate.Query;
import org.hibernate.Transaction;

import Babylon.Services.Filters.NewsItemFilter;
import Babylon.Services.Model.NewsItem;


/**
 *
 * @author guille
 */
public class NewsRepository implements INewsRepository {

    public String add(NewsItem item) {

        Session session = HibernateUtil.getSessionFactory().openSession();
        Transaction transaction = session.beginTransaction();

        session.save(item);

        transaction.commit();
        session.close();
        
        return item.getId();
    }

    public void update(NewsItem item) {

        Session session = HibernateUtil.getSessionFactory().openSession();
        Transaction transaction = session.beginTransaction();

        session.update(item);

        transaction.commit();
        session.close();
    }

    public void remove(NewsItem item) {

        Session session = HibernateUtil.getSessionFactory().openSession();
        Transaction transaction = session.beginTransaction();

        session.delete(item);

        transaction.commit();
        session.close();
    }

    public NewsItem getNewsItemByID(String id) {

        Session session = HibernateUtil.getSessionFactory().openSession();
        Transaction transaction = session.beginTransaction();

        NewsItem item = (NewsItem)session.get(NewsItem.class, id);

        transaction.commit();
        session.close();

        return item;
    }

    public List<NewsItem> getLatestNews(int count) {

        List<NewsItem> news = new ArrayList<NewsItem>();

        Session session = HibernateUtil.getSessionFactory().openSession();
        Transaction transaction = session.beginTransaction();

        Query query = session.createQuery("from NewsItem ni order by ni.reportedOn desc");
        query.setMaxResults(count);

        Iterator objects = query.list().iterator();

        while (objects.hasNext()) {
            NewsItem item = (NewsItem)objects.next();
            news.add(item);
        }

        transaction.commit();
        session.close();

        return news;
    }

    public List<NewsItem> searchNews(NewsItemFilter filter) {
        throw new UnsupportedOperationException("Not supported yet.");
    }

}

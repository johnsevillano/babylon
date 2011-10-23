/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */

package Babylon.Services.Repositories.Tests;

import java.util.ArrayList;
import java.util.Date;
import java.util.List;

import org.hibernate.SQLQuery;
import org.junit.After;
import org.junit.AfterClass;
import org.junit.Before;
import org.junit.BeforeClass;
import org.junit.Test;

import org.hibernate.Hibernate;
import org.hibernate.Session;
import org.hibernate.SessionFactory;
import org.hibernate.StatelessSession;
import org.hibernate.Transaction;
import org.hibernate.cfg.Configuration;
import org.hibernate.tool.hbm2ddl.SchemaExport;

import Babylon.Services.Model.NewsItem;
import Babylon.Services.Repositories.HibernateUtil;
import Babylon.Services.Repositories.NewsRepository;

/**
 *
 * @author guille
 */
public class NewsRepositoryTest {

    public NewsRepositoryTest() {
    }

    @BeforeClass
    public static void setUpClass() throws Exception {
        // load configuration file
        Configuration cfg = new Configuration();
        cfg.configure("hibernate.cfg.xml");

        // create tables
        new SchemaExport(cfg).create(false, true);
    }

    @AfterClass
    public static void tearDownClass() throws Exception {
    }

    @Before
    public void setUp() {
        createTestData();
    }

    @After
    public void tearDown() {
        removeTestData();
        HibernateUtil.getSessionFactory().close();
    }

    @Test
    public void addTest() {

        // Create transient news item
        NewsItem item = new NewsItem();
        item.setTitle("Title 4");
        item.setBody("Body 4");
        item.setReportedBy("reporter4");
        item.setReportedOn(new Date(System.currentTimeMillis()));

        // Persist news item
        NewsRepository repository = new NewsRepository();
        repository.add(item);

        // Check
        StringBuilder query = new StringBuilder();
        query.append("select TITLE ti, BODY bd, REPORTED_BY rb, REPORTED_ON ro");
        query.append(" from NEWS_ITEM where ID = :id");

        SessionFactory factory = HibernateUtil.getSessionFactory();
        StatelessSession session = factory.openStatelessSession();

        Object[] result = (Object[])
                session.createSQLQuery(query.toString())
                .addScalar("ti", Hibernate.STRING)
                .addScalar("bd", Hibernate.STRING)
                .addScalar("rb", Hibernate.STRING)
                .addScalar("ro", Hibernate.DATE)
                .setParameter("id", item.getId(), Hibernate.STRING)
                .uniqueResult();

        // close context
        session.close();

        assert result[0].getClass() == String.class;
        assert result[0].equals(item.getTitle());
        assert result[1].getClass() == String.class;
        assert result[1].equals(item.getBody());
        assert result[2].getClass() == String.class;
        assert result[2].equals(item.getReportedBy());
        assert result[3].getClass() == java.sql.Date.class;
    }

    @Test
    public void updateTest() {

        NewsItem item = news.get(0);

        item.setTitle("updated title");
        item.setBody("updated body");
        item.setReportedBy("updated reporter");
        item.setReportedOn(new Date(System.currentTimeMillis()));

        NewsRepository repository = new NewsRepository();
        repository.update(item);

        StringBuilder query = new StringBuilder();
        query.append("select TITLE ti, BODY bd, REPORTED_BY rb, REPORTED_ON ro");
        query.append(" from NEWS_ITEM where ID = :id");

        SessionFactory factory = HibernateUtil.getSessionFactory();
        StatelessSession session = factory.openStatelessSession();
        Object[] result = (Object[])
                session.createSQLQuery(query.toString())
                .addScalar("ti", Hibernate.STRING)
                .addScalar("bd", Hibernate.STRING)
                .addScalar("rb", Hibernate.STRING)
                .addScalar("ro", Hibernate.DATE)
                .setParameter("id", item.getId(), Hibernate.STRING)
                .uniqueResult();

        session.close();

        assert result[0].getClass() == String.class;
        assert result[0].equals(item.getTitle());
        assert result[1].getClass() == String.class;
        assert result[1].equals(item.getBody());
        assert result[2].getClass() == String.class;
        assert result[2].equals(item.getReportedBy());
        assert result[3].getClass() == java.sql.Date.class;
    }

    @Test
    public void removeTest() {

        NewsItem item = news.get(2);
        news.remove(2);

        NewsRepository repository = new NewsRepository();
        repository.remove(item);

        StringBuilder query = new StringBuilder();
        query.append("select ID id from NEWS_ITEM");
        query.append(" where ID = :id");

        SessionFactory factory = HibernateUtil.getSessionFactory();
        StatelessSession session = factory.openStatelessSession();

        Object result = session.createSQLQuery(query.toString())
                .addScalar("id", Hibernate.STRING)
                .setParameter("id", item.getId(), Hibernate.STRING)
                .uniqueResult();

        session.close();

        assert result == null;
    }

    @Test
    public void getNewsItemByIDTest() {

        NewsItem item = news.get(0);

        NewsRepository repository = new NewsRepository();
        NewsItem itemFromDB = repository.getNewsItemByID(item.getId());

        assert itemFromDB.getId().equals(item.getId());
        assert itemFromDB.getTitle().equals(item.getTitle());
        assert itemFromDB.getBody().equals(item.getBody());
        assert itemFromDB.getReportedBy().equals(item.getReportedBy());
    }

    @Test
    public void getLatestNewsTest() {

        NewsRepository repository = new NewsRepository();
        List<NewsItem> latestNews = repository.getLatestNews(2);

        assert latestNews.size() == 2;
        assert latestNews.get(0).getClass() == NewsItem.class;
        assert latestNews.get(1).getClass() == NewsItem.class;
    }

    private List<NewsItem> news = new ArrayList<NewsItem>();

    private void createTestData() {

        // create transient news item 1
        NewsItem newsItem1 = new NewsItem();
        newsItem1.setTitle("This is the title 1");
        newsItem1.setBody("This is the body of the news item 1.");
        newsItem1.setReportedBy("reporter1");
        newsItem1.setReportedOn(new Date(System.currentTimeMillis()));

        // create transiente news item 2
        NewsItem newsItem2 = new NewsItem();
        newsItem2.setTitle("This is the title 2");
        newsItem2.setBody("This is the body of the news item 2.");
        newsItem2.setReportedBy("reporter2");
        newsItem2.setReportedOn(new Date(System.currentTimeMillis()));

        // create transiente news item 3
        NewsItem newsItem3 = new NewsItem();
        newsItem3.setTitle("This is the title 3");
        newsItem3.setBody("This is the body of the news item 3.");
        newsItem3.setReportedBy("reporter2");
        newsItem3.setReportedOn(new Date(System.currentTimeMillis()));

        // open new persistence context
        Session session = HibernateUtil.getSessionFactory().openSession();
        Transaction transaction = session.beginTransaction();

        // make news persistent
        session.save(newsItem1);
        session.save(newsItem2);
        session.save(newsItem3);

        // commit changes
        transaction.commit();

        // close persistence context
        session.close();

        // keep references to detached news for later use
        news.add(newsItem1);
        news.add(newsItem2);
        news.add(newsItem3);
    }

    private void removeTestData() {

        // open a new persistence context
        SessionFactory factory = HibernateUtil.getSessionFactory();
        StatelessSession session = factory.openStatelessSession();
        
        // begin transaction
        Transaction transaction = session.beginTransaction();

        // delete news
        SQLQuery query = session.createSQLQuery("delete from NEWS_ITEM");
        query.executeUpdate();

        // commit changes
        transaction.commit();

        // close persistence context
        session.close();
    }

}
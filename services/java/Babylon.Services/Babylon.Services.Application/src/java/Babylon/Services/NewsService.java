/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */

package Babylon.Services;

import java.util.List;
import javax.jws.Oneway;
import javax.jws.WebMethod;
import javax.jws.WebParam;
import javax.jws.WebService;

import Babylon.Services.Model.NewsItem;
import Babylon.Services.Filters.NewsItemFilter;
import Babylon.Services.Repositories.INewsRepository;
import Babylon.Services.Repositories.NewsRepository;
import java.util.Date;


/**
 *
 * @author guille
 */
@WebService()
public class NewsService {

    private INewsRepository repository;

    /**
     * Web service operation
     */
    @WebMethod(operationName = "CreateNewsItem")
    public String CreateNewsItem(
            @WebParam(name = "title") String title,
            @WebParam(name = "body") String body,
            @WebParam(name = "reportedBy") String reportedBy)
    {
        NewsItem newsItem = new NewsItem();

        newsItem.setId("000000");
        newsItem.setTitle(title);
        newsItem.setBody(body);
        newsItem.setReportedBy(reportedBy);

        return newsItem.getId();
    }

    /**
     * Web service operation
     */
    @WebMethod(operationName = "ReportNewsItem")
    @Oneway
    public void ReportNewsItem(@WebParam(name = "newsItem") NewsItem newsItem)
    {
        newsItem.setReportedOn(new Date(System.currentTimeMillis()));
        getRepository().add(newsItem);
    }

    /**
     * Web service operation
     */
    @WebMethod(operationName = "GetLatestNews")
    public List<NewsItem> GetLatestNews(@WebParam(name = "count") int count)
    {
        return getRepository().getLatestNews(count);
    }

    /**
     * Web service operation
     */
    @WebMethod(operationName = "GetNewsItem")
    public NewsItem GetNewsItem(@WebParam(name = "id") String id)
    {
        return getRepository().getNewsItemByID(id);
    }

    /**
     * Web service operation
     */
    @WebMethod(operationName = "ModifyNewsItem")
    @Oneway
    public void ModifyNewsItem(@WebParam(name = "item") NewsItem item)
    {
        getRepository().update(item);
    }

    /**
     * Web service operation
     */
    @WebMethod(operationName = "DeleteNewsItem")
    @Oneway
    public void DeleteNewsItem(@WebParam(name = "id") String id)
    {
        NewsItem item = getRepository().getNewsItemByID(id);
        getRepository().remove(item);
    }

    /**
     * Web service operation
     */
    @WebMethod(operationName = "SearchNews")
    public List<NewsItem> SearchNews(@WebParam(name = "filter") NewsItemFilter filter)
    {
        return getRepository().searchNews(filter);
    }

    /**
     * 
     * @return
     */
    private INewsRepository getRepository() {

        if (repository == null) {
            repository = new NewsRepository();
        }

        return repository;
    }

}

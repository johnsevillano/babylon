/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */

package Babylon.Services.Repositories;

import java.util.List;

import Babylon.Services.Model.NewsItem;
import Babylon.Services.Filters.NewsItemFilter;


/**
 *
 * @author guille
 */
public interface INewsRepository {

    /**
     * This method adds a news item.
     * @param item
     * @return
     */
    String add(NewsItem item);

    /**
     * This method updates an existing news item.
     * @param item
     */
    void update(NewsItem item);

    /**
     * This method removes an existing news item.
     * @param item
     */
    void remove(NewsItem item);

    /**
     * This method gets a news item by its ID.
     * @param id
     * @return
     */
    NewsItem getNewsItemByID(String id);

    /**
     * This method gets the 'count' latest news.
     * @param count
     * @return
     */
    List<NewsItem> getLatestNews(int count);

    /**
     * This method searchs for news.
     * @param filter
     * @return
     */
    List<NewsItem> searchNews(NewsItemFilter filter);

}

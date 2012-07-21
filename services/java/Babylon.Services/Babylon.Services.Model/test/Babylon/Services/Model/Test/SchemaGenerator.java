/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */

package Babylon.Services.Model.Test;

import org.hibernate.cfg.Configuration;
import org.hibernate.tool.hbm2ddl.SchemaExport;
import org.junit.*;


/**
 *
 * @author guille
 */
public class SchemaGenerator {

    public SchemaGenerator() {
    }

    @BeforeClass
    public static void setUpClass() throws Exception {
    }

    @AfterClass
    public static void tearDownClass() throws Exception {
    }

    @Before
    public void setUp() {
    }

    @After
    public void tearDown() {
    }

    @Test
    public void createSchema() {

        // Load configuration file
        Configuration cfg = new Configuration();
        cfg.configure("hibernate.cfg.xml");

        // Create database
        new SchemaExport(cfg).create(false, true);
    }

    @Test
    public void dropSchema() {
        // Load configuration file
        Configuration cfg = new Configuration();
        cfg.configure("hibernate.cfg.xml");

        // Create database
        new SchemaExport(cfg).drop(false, true);
    }

}
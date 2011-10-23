/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */

package Babylon.Services.Model.Test;

import org.junit.After;
import org.junit.AfterClass;
import org.junit.Before;
import org.junit.BeforeClass;
import org.junit.Test;
import static org.junit.Assert.*;

import org.hibernate.tool.hbm2ddl.SchemaExport;
import org.hibernate.cfg.Configuration;


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
    }

}
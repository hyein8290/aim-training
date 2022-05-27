package kr.co.aim.mavenserver;

import java.util.HashMap;
import java.util.List;
import java.util.Map;
import java.util.Optional;

import javax.sql.DataSource;

import org.springframework.jdbc.core.JdbcTemplate;
import org.springframework.jdbc.core.RowMapper;
import org.springframework.jdbc.core.namedparam.MapSqlParameterSource;
import org.springframework.jdbc.core.simple.SimpleJdbcInsert;
import org.springframework.jdbc.datasource.DriverManagerDataSource;
import org.springframework.stereotype.Component;

@Component
public class UserDAO {
   private String driver = "oracle.jdbc.OracleDriver";
   private String url = "jdbc:oracle:thin:@//localhost:1521/xe";
   private String username = "chat";
   private String password = "java1234";
   
   private DriverManagerDataSource dataSource;
   private JdbcTemplate jdbcTemplate;
   
   public UserDAO() {
      dataSource = new DriverManagerDataSource();
      dataSource.setDriverClassName(driver);
      dataSource.setUrl(url);
      dataSource.setUsername(username);
      dataSource.setPassword(password);
      
      jdbcTemplate = new JdbcTemplate();
      jdbcTemplate.setDataSource(dataSource);
   }
   
   public int add(User user) {
      String sql = "insert into member (id, name) values (?,?)";
      int result = jdbcTemplate.update(sql, user.getId(), user.getName());

      return result;
   }
}
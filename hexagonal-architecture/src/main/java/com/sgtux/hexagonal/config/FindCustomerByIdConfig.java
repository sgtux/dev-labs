package com.sgtux.hexagonal.config;

import org.springframework.context.annotation.Bean;
import org.springframework.context.annotation.Configuration;

import com.sgtux.hexagonal.adapters.out.FindCustomerByIdAdapter;
import com.sgtux.hexagonal.application.core.usecase.FindCustomerByIdUseCase;

@Configuration
public class FindCustomerByIdConfig {

    @Bean
    public FindCustomerByIdUseCase findCustomerByIdUseCase(
            FindCustomerByIdAdapter findCustomerByIdAdapter) {
        return new FindCustomerByIdUseCase(findCustomerByIdAdapter);
    }
}

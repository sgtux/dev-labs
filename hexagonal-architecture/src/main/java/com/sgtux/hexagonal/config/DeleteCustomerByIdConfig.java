package com.sgtux.hexagonal.config;

import org.springframework.context.annotation.Bean;
import org.springframework.context.annotation.Configuration;

import com.sgtux.hexagonal.adapters.out.DeleteCustomerByIdAdapter;
import com.sgtux.hexagonal.application.core.usecase.DeleteCustomerbyIdUseCase;
import com.sgtux.hexagonal.application.core.usecase.FindCustomerByIdUseCase;

@Configuration
public class DeleteCustomerByIdConfig {

    @Bean
    public DeleteCustomerbyIdUseCase deleteCustomerByIdUseCase(
            FindCustomerByIdUseCase findCustomerByIdUseCase,
            DeleteCustomerByIdAdapter deleteCustomerByIdAdapter) {
        return new DeleteCustomerbyIdUseCase(findCustomerByIdUseCase, deleteCustomerByIdAdapter);
    }
}
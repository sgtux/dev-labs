package com.sgtux.hexagonal.config;

import org.springframework.context.annotation.Bean;
import org.springframework.context.annotation.Configuration;

import com.sgtux.hexagonal.adapters.out.FindAddressByZipCodeAdapter;
import com.sgtux.hexagonal.adapters.out.UpdateCustomerAdapter;
import com.sgtux.hexagonal.application.core.usecase.FindCustomerByIdUseCase;
import com.sgtux.hexagonal.application.core.usecase.UpdateCustomerUseCase;

@Configuration
public class UpdateCustomerConfig {

    @Bean 
    public UpdateCustomerUseCase updateCustomerUseCase(
        FindCustomerByIdUseCase findCustomerByIdUseCase,
        FindAddressByZipCodeAdapter findAddressByZipCodeAdapter,
        UpdateCustomerAdapter updateCustomerAdapter
    ){
        return new UpdateCustomerUseCase(findCustomerByIdUseCase, findAddressByZipCodeAdapter, updateCustomerAdapter);
    }
}

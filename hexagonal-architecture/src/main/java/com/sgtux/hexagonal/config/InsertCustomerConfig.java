package com.sgtux.hexagonal.config;

import org.springframework.context.annotation.Bean;
import org.springframework.context.annotation.Configuration;

import com.sgtux.hexagonal.adapters.out.FindAddressByZipCodeAdapter;
import com.sgtux.hexagonal.adapters.out.InsertCustomerAdapter;
import com.sgtux.hexagonal.adapters.out.SendCpfValidationAdapter;
import com.sgtux.hexagonal.application.core.usecase.InsertCustomerUseCase;

@Configuration
public class InsertCustomerConfig {

    @Bean
    public InsertCustomerUseCase insertCustomerUseCase(
            FindAddressByZipCodeAdapter findAddressByZipCodeAdapter,
            InsertCustomerAdapter insertCustomerAdapter,
            SendCpfValidationAdapter sendCpfValidationAdapter) {
        return new InsertCustomerUseCase(findAddressByZipCodeAdapter, insertCustomerAdapter, sendCpfValidationAdapter);
    }
}

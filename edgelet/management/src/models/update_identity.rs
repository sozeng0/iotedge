/*
 * IoT Edge Module Management API
 *
 * No description provided (generated by Swagger Codegen https://github.com/swagger-api/swagger-codegen)
 *
 * OpenAPI spec version: 2018-06-28
 *
 * Generated by: https://github.com/swagger-api/swagger-codegen.git
 */

#[allow(unused_imports)]
use serde_json::Value;

#[derive(Debug, Serialize, Deserialize)]
pub struct UpdateIdentity {
    #[serde(rename = "generationId")]
    generation_id: String,
}

impl UpdateIdentity {
    pub fn new(generation_id: String) -> UpdateIdentity {
        UpdateIdentity { generation_id }
    }

    pub fn set_generation_id(&mut self, generation_id: String) {
        self.generation_id = generation_id;
    }

    pub fn with_generation_id(mut self, generation_id: String) -> UpdateIdentity {
        self.generation_id = generation_id;
        self
    }

    pub fn generation_id(&self) -> &String {
        &self.generation_id
    }
}
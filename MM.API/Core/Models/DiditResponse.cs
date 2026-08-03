using Newtonsoft.Json;

namespace MM.API.Core.Models
{
    public class AdditionalInformation
    {
        public IReadOnlyList<object>? flag_summary { get; set; }
    }

    public class AddressComponent
    {
        public string? long_name { get; set; }
        public string? short_name { get; set; }
        public IReadOnlyList<string>? types { get; set; }
    }

    public class AmlScreening
    {
        public string? entity_type { get; set; }
        public IReadOnlyList<Hit>? hits { get; set; }
        public bool? is_ongoing_monitoring_enabled { get; set; }
        public object? next_ongoing_monitoring_bill_date { get; set; }
        public string? node_id { get; set; }
        public double? score { get; set; }
        public ScreenedData? screened_data { get; set; }
        public string? status { get; set; }
        public int? total_hits { get; set; }
        public IReadOnlyList<object>? warnings { get; set; }
    }

    public class Answer
    {
        public string? value { get; set; }
        public string? text { get; set; }
        public IReadOnlyList<string>? files { get; set; }
    }

    public class Authenticity
    {
        public bool? dg_integrity { get; set; }
        public bool? sod_integrity { get; set; }
    }

    public class BackImageQualityScore
    {
        public string? brightness_issue { get; set; }
        public double? brightness_score { get; set; }
        public double? focus_score { get; set; }
        public bool? is_document_fully_visible { get; set; }
        public double? overall_score { get; set; }
        public double? resolution_score { get; set; }
    }

    public class Bounds
    {
        public Northeast? northeast { get; set; }
        public Southwest? southwest { get; set; }
    }

    public class Carrier
    {
        public string? name { get; set; }
        public string? type { get; set; }
    }

    public class Categories
    {
        public double? score { get; set; }
        public double? weightage { get; set; }
        public string? risk_level { get; set; }
        public RiskScores? risk_scores { get; set; }
    }

    public class CertificateSummary
    {
        public string? issuer { get; set; }
        public string? not_valid_after { get; set; }
        public string? not_valid_before { get; set; }
        public double? serial_number { get; set; }
        public string? subject { get; set; }
    }

    public class ChipData
    {
        public string? address { get; set; }
        public string? birth_date { get; set; }
        public string? birth_date_hash { get; set; }
        public string? country { get; set; }
        public IReadOnlyList<string>? dgs { get; set; }
        public string? document_number { get; set; }
        public string? document_number_hash { get; set; }
        public string? document_type { get; set; }
        public string? expiry_date { get; set; }
        public string? expiry_date_hash { get; set; }
        public string? final_hash { get; set; }
        public string? mrz_string { get; set; }
        public string? mrz_type { get; set; }
        public string? name { get; set; }
        public string? nationality { get; set; }
        public string? optional_data { get; set; }
        public string? optional_data_hash { get; set; }
        public string? place_of_birth { get; set; }
        public string? sex { get; set; }
        public string? surname { get; set; }
    }

    public class Choice
    {
        public string? label { get; set; }
        public string? value { get; set; }
        public bool? requires_text_input { get; set; }
    }

    public class Countries
    {
        public double? score { get; set; }
        public double? weightage { get; set; }
        public string? risk_level { get; set; }
        public RiskScores? risk_scores { get; set; }
    }

    public class Crimes
    {
        public double? score { get; set; }
        public double? weightage { get; set; }
        public string? risk_level { get; set; }
        public RiskScores? risk_scores { get; set; }
    }

    public class CustomList
    {
    }

    public class DatabaseValidation
    {
        public string? node_id { get; set; }
        public string? issuing_state { get; set; }
        public string? validation_type { get; set; }
        public ScreenedData? screened_data { get; set; }
        public IReadOnlyList<Validation>? validations { get; set; }
        public string? match_type { get; set; }
        public string? status { get; set; }
        public IReadOnlyList<object>? warnings { get; set; }
    }

    public class Decision
    {
        public IReadOnlyList<AmlScreening>? aml_screenings { get; set; }
        public string? callback { get; set; }
        public object? contact_details { get; set; }
        public DateTime created_at { get; set; }
        public IReadOnlyList<DatabaseValidation>? database_validations { get; set; }
        public IReadOnlyList<EmailVerification>? email_verifications { get; set; }
        public object? expected_details { get; set; }
        public IReadOnlyList<FaceMatch>? face_matches { get; set; }
        public IReadOnlyList<string>? features { get; set; }
        public IReadOnlyList<IdVerification>? id_verifications { get; set; }
        public IReadOnlyList<IpAnalysis>? ip_analyses { get; set; }
        public IReadOnlyList<LivenessCheck>? liveness_checks { get; set; }
        public object? metadata { get; set; }
        public IReadOnlyList<NfcVerification>? nfc_verifications { get; set; }
        public IReadOnlyList<PhoneVerification>? phone_verifications { get; set; }
        public IReadOnlyList<PoaVerification>? poa_verifications { get; set; }
        public IReadOnlyList<QuestionnaireResponse>? questionnaire_responses { get; set; }
        public IReadOnlyList<Review>? reviews { get; set; }
        public string? session_id { get; set; }
        public int? session_number { get; set; }
        public string? session_url { get; set; }
        public string? status { get; set; }
        public string? vendor_data { get; set; }
        public string? workflow_id { get; set; }
    }

    public class Review
    {
        public string? comment { get; set; }
        public DateTime created_at { get; set; }
        public string? new_status { get; set; }
        public string? user { get; set; }
    }

    public class Details
    {
        public object? reason { get; set; }
        public string? status { get; set; }
        public string? code_tried { get; set; }
        public string? actual_channel { get; set; }
        public string? channel { get; set; }
    }

    public class DistanceFromIdDocument
    {
        public string? direction { get; set; }
        public double? distance { get; set; }
    }

    public class DistanceFromIp
    {
        public string? direction { get; set; }
        public double? distance { get; set; }
    }

    public class DistanceFromPoaDocument
    {
        public string? direction { get; set; }
        public double? distance { get; set; }
    }

    public class DocumentLocation
    {
        public double? latitude { get; set; }
        public double? longitude { get; set; }
    }

    public class DocumentMetadata
    {
        public string? content_type { get; set; }
        public DateTime creation_date { get; set; }
        public int? file_size { get; set; }
        public DateTime modified_date { get; set; }
    }

    public class EmailVerification
    {
        public IReadOnlyList<object>? breaches { get; set; }
        public string? email { get; set; }
        public bool? is_breached { get; set; }
        public bool? is_disposable { get; set; }
        public bool? is_undeliverable { get; set; }
        public IReadOnlyList<Lifecycle>? lifecycle { get; set; }
        public string? node_id { get; set; }
        public string? status { get; set; }
        public int? verification_attempts { get; set; }
        public DateTime verified_at { get; set; }
        public IReadOnlyList<object>? warnings { get; set; }
    }

    public class ExtraFields
    {
        public string? first_surname { get; set; }
        public string? second_surname { get; set; }
        public IReadOnlyList<object>? additional_names { get; set; }
        public object? bank_account_number { get; set; }
        public object? bank_branch_address { get; set; }
        public object? bank_branch_name { get; set; }
        public object? bank_iban { get; set; }
        public object? bank_routing_number { get; set; }
        public object? bank_sort_code { get; set; }
        public object? bank_swift_bic { get; set; }
        public object? document_phone_number { get; set; }
    }

    public class FaceMatch
    {
        public string? node_id { get; set; }
        public double? score { get; set; }
        public string? source_image { get; set; }
        public object? source_image_session_id { get; set; }
        public string? status { get; set; }
        public string? target_image { get; set; }
        public IReadOnlyList<object>? warnings { get; set; }
    }

    public class FrontImageQualityScore
    {
        public string? brightness_issue { get; set; }
        public double? brightness_score { get; set; }
        public double? focus_score { get; set; }
        public bool? is_document_fully_visible { get; set; }
        public double? overall_score { get; set; }
        public double? resolution_score { get; set; }
    }

    public class Geometry
    {
        public Bounds? bounds { get; set; }
        public Location? location { get; set; }
        public string? location_type { get; set; }
        public Viewport? viewport { get; set; }
    }

    public class Hit
    {
        public string? id { get; set; }
        public string? url { get; set; }
        public bool? match { get; set; }
        public double? score { get; set; }
        public object? target { get; set; }
        public string? caption { get; set; }
        public IReadOnlyList<string>? datasets { get; set; }
        public object? features { get; set; }
        public string? rca_name { get; set; }
        public DateTime last_seen { get; set; }
        public RiskView? risk_view { get; set; }
        public DateTime first_seen { get; set; }
        public Properties? properties { get; set; }
        public double? match_score { get; set; }
        public double? risk_score { get; set; }
        public string? review_status { get; set; }
        public ScoreBreakdown? score_breakdown { get; set; }
        public IReadOnlyList<PepMatch>? pep_matches { get; set; }
        public IReadOnlyList<object>? linked_entities { get; set; }
        public IReadOnlyList<object>? warning_matches { get; set; }
        public IReadOnlyList<object>? sanction_matches { get; set; }
        public object? adverse_media_details { get; set; }
        public IReadOnlyList<object>? adverse_media_matches { get; set; }
        public AdditionalInformation? additional_information { get; set; }
    }

    public class IdDocument
    {
        public DistanceFromIp? distance_from_ip { get; set; }
        public DistanceFromPoaDocument? distance_from_poa_document { get; set; }
        public Location? location { get; set; }
    }

    public class IdVerification
    {
        public string? address { get; set; }
        public int? age { get; set; }
        public string? back_image { get; set; }
        public string? back_image_camera_front { get; set; }
        public double? back_image_camera_front_face_match_score { get; set; }
        public BackImageQualityScore? back_image_quality_score { get; set; }
        public string? back_video { get; set; }
        public string? date_of_birth { get; set; }
        public string? date_of_issue { get; set; }
        public string? document_number { get; set; }
        public string? document_type { get; set; }
        public string? expiration_date { get; set; }
        public ExtraFields? extra_fields { get; set; }
        public IReadOnlyList<object>? extra_files { get; set; }
        public string? first_name { get; set; }
        public string? formatted_address { get; set; }
        public string? front_image { get; set; }
        public string? front_image_camera_front { get; set; }
        public double? front_image_camera_front_face_match_score { get; set; }
        public FrontImageQualityScore? front_image_quality_score { get; set; }
        public string? front_video { get; set; }
        public string? full_back_image { get; set; }
        public string? full_front_image { get; set; }
        public string? full_name { get; set; }
        public string? gender { get; set; }
        public string? issuing_state { get; set; }
        public string? issuing_state_name { get; set; }
        public string? last_name { get; set; }
        public string? marital_status { get; set; }
        public IReadOnlyList<object>? matches { get; set; }
        public string? nationality { get; set; }
        public string? node_id { get; set; }
        public ParsedAddress? parsed_address { get; set; }
        public string? personal_number { get; set; }
        public string? place_of_birth { get; set; }
        public string? portrait_image { get; set; }
        public string? status { get; set; }
        public IReadOnlyList<object>? warnings { get; set; }
    }

    public class Ip
    {
        public DistanceFromIdDocument? distance_from_id_document { get; set; }
        public DistanceFromPoaDocument? distance_from_poa_document { get; set; }
        public Location? location { get; set; }
    }

    public class IpAnalysis
    {
        public string? browser_family { get; set; }
        public string? device_brand { get; set; }
        public object? device_fingerprint { get; set; }
        public object? device_model { get; set; }
        public IdDocument? id_document { get; set; }
        public Ip? ip { get; set; }
        public string? ip_address { get; set; }
        public string? ip_city { get; set; }
        public string? ip_country { get; set; }
        public string? ip_country_code { get; set; }
        public string? ip_state { get; set; }
        public bool? is_data_center { get; set; }
        public bool? is_vpn_or_tor { get; set; }
        public string? isp { get; set; }
        //public double? latitude { get; set; }
        //public double? longitude { get; set; }
        public string? node_id { get; set; }
        public string? organization { get; set; }
        public string? os_family { get; set; }
        public string? platform { get; set; }
        public PoaDocument? poa_document { get; set; }
        public string? status { get; set; }
        //public string? time_zone { get; set; }
        //public int? time_zone_offset { get; set; }
        public IReadOnlyList<object>? warnings { get; set; }
    }

    public class Item
    {
        public Answer? answer { get; set; }
        public IReadOnlyList<Choice>? choices { get; set; }
        public object? description { get; set; }
        public string? element_type { get; set; }
        public bool? is_required { get; set; }
        public int? max_files { get; set; }
        public object? placeholder { get; set; }
        public object? repeatable_config { get; set; }
        public object? required_if { get; set; }
        public string? title { get; set; }
        public string? uuid { get; set; }
        public string? value { get; set; }
    }

    public class Lifecycle
    {
        public Details? details { get; set; }
        public double? fee { get; set; }
        public DateTime timestamp { get; set; }
        public string? type { get; set; }
    }

    public class LivenessCheck
    {
        public double? age_estimation { get; set; }
        public object? face_luminance { get; set; }
        public object? face_quality { get; set; }
        public IReadOnlyList<object>? matches { get; set; }
        public string? method { get; set; }
        public string? node_id { get; set; }
        public string? reference_image { get; set; }
        public double? score { get; set; }
        public string? status { get; set; }
        public object? video_url { get; set; }
        public IReadOnlyList<object>? warnings { get; set; }
    }

    public class Location
    {
        public double? lat { get; set; }
        public double? lng { get; set; }
        public double? latitude { get; set; }
        public double? longitude { get; set; }
    }

    public class NavigationPoint
    {
        public Location? location { get; set; }
    }

    public class NfcVerification
    {
        public Authenticity? authenticity { get; set; }
        public CertificateSummary? certificate_summary { get; set; }
        public ChipData? chip_data { get; set; }
        public string? node_id { get; set; }
        public string? portrait_image { get; set; }
        public string? signature_image { get; set; }
        public string? status { get; set; }
        public IReadOnlyList<object>? warnings { get; set; }
    }

    public class Northeast
    {
        public double? lat { get; set; }
        public double? lng { get; set; }
    }

    public class ParsedAddress
    {
        public string? address_type { get; set; }
        public string? category { get; set; }
        public string? city { get; set; }
        public string? country { get; set; }
        public DocumentLocation? document_location { get; set; }
        public string? formatted_address { get; set; }
        public bool? is_verified { get; set; }
        public string? label { get; set; }
        public string? postal_code { get; set; }
        public RawResults? raw_results { get; set; }
        public string? region { get; set; }
        public string? street_1 { get; set; }
        public object? street_2 { get; set; }
    }

    public class PepMatch
    {
        public IReadOnlyList<string>? aliases { get; set; }
        public IReadOnlyList<object>? education { get; set; }
        public string? list_name { get; set; }
        public string? publisher { get; set; }
        public string? source_url { get; set; }
        public string? description { get; set; }
        public string? matched_name { get; set; }
        public string? pep_position { get; set; }
        public string? date_of_birth { get; set; }
        public IReadOnlyList<object>? other_sources { get; set; }
        public string? place_of_birth { get; set; }
    }

    public class PhoneVerification
    {
        public Carrier? carrier { get; set; }
        public string? country_code { get; set; }
        public string? country_name { get; set; }
        public string? full_number { get; set; }
        public bool? is_disposable { get; set; }
        public bool? is_virtual { get; set; }
        public IReadOnlyList<Lifecycle>? lifecycle { get; set; }
        public string? node_id { get; set; }
        public string? phone_number { get; set; }
        public string? phone_number_prefix { get; set; }
        public string? status { get; set; }
        public int? verification_attempts { get; set; }
        public string? verification_method { get; set; }
        public DateTime verified_at { get; set; }
        public IReadOnlyList<object>? warnings { get; set; }
    }

    public class PoaDocument
    {
        public DistanceFromIdDocument? distance_from_id_document { get; set; }
        public DistanceFromIp? distance_from_ip { get; set; }
        public Location? location { get; set; }
    }

    public class PoaParsedAddress
    {
        public string? address_type { get; set; }
        public string? category { get; set; }
        public string? city { get; set; }
        public string? country { get; set; }
        public DocumentLocation? document_location { get; set; }
        public string? formatted_address { get; set; }
        public string? id { get; set; }
        public bool? is_best_match { get; set; }
        public bool? is_verified { get; set; }
        public string? label { get; set; }
        public string? postal_code { get; set; }
        public RawResults? raw_results { get; set; }
        public string? region { get; set; }
        public string? street_1 { get; set; }
        public object? street_2 { get; set; }
    }

    public class PoaVerification
    {
        public string? document_file { get; set; }
        public string? document_language { get; set; }
        public DocumentMetadata? document_metadata { get; set; }
        public string? document_type { get; set; }
        public object? expected_details_address { get; set; }
        public object? expected_details_formatted_address { get; set; }
        public object? expected_details_parsed_address { get; set; }
        public string? expiration_date { get; set; }
        public ExtraFields? extra_fields { get; set; }
        public IReadOnlyList<object>? extra_files { get; set; }
        public string? issue_date { get; set; }
        public string? issuer { get; set; }
        public string? issuing_state { get; set; }
        public object? name_match_score_expected_details { get; set; }
        public double? name_match_score_id_verification { get; set; }
        public string? name_on_document { get; set; }
        public string? node_id { get; set; }
        public string? poa_address { get; set; }
        public string? poa_formatted_address { get; set; }
        public PoaParsedAddress? poa_parsed_address { get; set; }
        public string? status { get; set; }
        public IReadOnlyList<object>? warnings { get; set; }
    }

    public class Properties
    {
        public IReadOnlyList<string>? name { get; set; }
        public IReadOnlyList<string>? alias { get; set; }
        public IReadOnlyList<string>? notes { get; set; }
        public object? title { get; set; }
        public IReadOnlyList<string>? gender { get; set; }
        public object? height { get; set; }
        public object? topics { get; set; }
        public object? weight { get; set; }
        public object? address { get; set; }
        public IReadOnlyList<string>? country { get; set; }
        public object? website { get; set; }
        public object? eyeColor { get; set; }
        public object? keywords { get; set; }
        public IReadOnlyList<string>? lastName { get; set; }
        public IReadOnlyList<string>? position { get; set; }
        public object? religion { get; set; }
        public IReadOnlyList<string>? birthDate { get; set; }
        public IReadOnlyList<object>? education { get; set; }
        public object? ethnicity { get; set; }
        public IReadOnlyList<string>? firstName { get; set; }
        public object? hairColor { get; set; }
        public object? weakAlias { get; set; }
        public IReadOnlyList<string>? birthPlace { get; set; }
        public object? modifiedAt { get; set; }
        public object? wikidataId { get; set; }
        public object? citizenship { get; set; }
        public IReadOnlyList<string>? nationality { get; set; }
    }

    public class QuestionnaireResponse
    {
        public string? default_language { get; set; }
        public string? description { get; set; }
        public bool? is_active { get; set; }
        public bool? is_simple_questionnaire { get; set; }
        public IReadOnlyList<string>? languages { get; set; }
        public string? node_id { get; set; }
        public string? published_at { get; set; }
        public string? questionnaire_group_id { get; set; }
        public string? questionnaire_id { get; set; }
        public IReadOnlyList<Section>? sections { get; set; }
        public string? status { get; set; }
        public string? title { get; set; }
        public int? version { get; set; }
    }

    public class RawResults
    {
        public IReadOnlyList<AddressComponent>? address_components { get; set; }
        public string? formatted_address { get; set; }
        public Geometry? geometry { get; set; }
        public IReadOnlyList<NavigationPoint>? navigation_points { get; set; }
        public bool? partial_match { get; set; }
        public string? place_id { get; set; }
        public IReadOnlyList<string>? types { get; set; }
    }

    public class RiskScores
    {
        [JsonProperty("United States")]
        public double? UnitedStates { get; set; }

        public int? PEP { get; set; }
    }

    public class RiskView
    {
        public Crimes? crimes { get; set; }
        public Countries? countries { get; set; }
        public Categories? categories { get; set; }
        public CustomList? custom_list { get; set; }
    }

    public class DiditResponse
    {
        public int? created_at { get; set; }
        public Decision? decision { get; set; }
        public string? session_id { get; set; }
        public string? status { get; set; }
        public int? timestamp { get; set; }
        public string? vendor_data { get; set; }
        public string? webhook_type { get; set; }
        public string? workflow_id { get; set; }
        public int? workflow_version { get; set; }
    }

    public class ScoreBreakdown
    {
        public double? name_score { get; set; }
        public double? name_weight { get; set; }
        public double? name_weight_normalized { get; set; }
        public double? name_contribution { get; set; }
        public double? dob_score { get; set; }
        public double? dob_weight { get; set; }
        public double? dob_weight_normalized { get; set; }
        public double? dob_contribution { get; set; }
        public double? country_score { get; set; }
        public double? country_weight { get; set; }
        public double? country_weight_normalized { get; set; }
        public double? country_contribution { get; set; }
        public string? document_number_match_type { get; set; }
        public string? document_number_effect { get; set; }
        public double? total_score { get; set; }
    }

    public class ScreenedData
    {
        public string? date_of_birth { get; set; }
        public string? document_number { get; set; }
        public string? full_name { get; set; }
        public string? nationality { get; set; }
        public string? last_name { get; set; }
        public string? first_name { get; set; }
        public string? tax_number { get; set; }
        public string? document_type { get; set; }
        public string? expiration_date { get; set; }
    }

    public class Section
    {
        public object? description { get; set; }
        public IReadOnlyList<Item>? items { get; set; }
        public object? title { get; set; }
    }

    public class SourceData
    {
        public string? identification_number { get; set; }
        public string? first_name { get; set; }
        public string? last_name { get; set; }
        public string? date_of_birth { get; set; }
        public string? gender { get; set; }
        public string? nationality { get; set; }
    }

    public class Southwest
    {
        public double? lat { get; set; }
        public double? lng { get; set; }
    }

    public class Validation
    {
        public Validation? validation { get; set; }
        public SourceData? source_data { get; set; }
    }

    public class Validation2
    {
        public string? full_name { get; set; }
        public string? date_of_birth { get; set; }
        public string? identification_number { get; set; }
    }

    public class Viewport
    {
        public Northeast? northeast { get; set; }
        public Southwest? southwest { get; set; }
    }
}